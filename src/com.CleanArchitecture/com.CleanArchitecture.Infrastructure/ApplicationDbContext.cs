using com.CleanArchitecture.Application.Exceptions;
using com.CleanArchitecture.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public ApplicationDbContext(DbContextOptions options, IPublisher publisher):base(options)
        {
            _publisher = publisher;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // aplica todas las configuraciones del assembly actual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                // Implementación personalizada de SaveChangesAsync
                var result = await base.SaveChangesAsync(cancellationToken);
                // Aquí puedes agregar lógica adicional si es necesario
                await PublishDomainEventsAsync();
                return result;
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("La excepcion por concurrencia se disparo", ex);
            }
        }

        /// Implementación personalizada de SaveChanges
        private async Task PublishDomainEventsAsync()
        {
            var domainEvents = ChangeTracker
                 .Entries<IEntity>()
                 .Select(entry => entry.Entity)
                 .SelectMany(entity =>
                 {
                     var domainEvents = entity.GetDomainEvents();
                     entity.ClearDomainEvents();
                     return domainEvents;
                 }).ToList();
            foreach(var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent);
            }
        }
    }
}
