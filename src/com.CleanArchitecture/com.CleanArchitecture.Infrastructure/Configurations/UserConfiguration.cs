using com.CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class UserConfiguration :IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre)
                .HasMaxLength(200)
                .HasConversion(nombre => nombre!.Value, value => new Nombre(value));
            builder.Property(x => x.Apellido)
                .HasMaxLength(200)
                .HasConversion(apellido => apellido!.Value, value => new Apellido(value));
            builder.Property(x => x.Email)
                .HasMaxLength(500)
                .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));
            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}
