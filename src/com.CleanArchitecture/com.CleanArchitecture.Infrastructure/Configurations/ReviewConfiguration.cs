using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Comentarios;
using com.CleanArchitecture.Domain.Users;
using com.CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("reviews");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x!.Value, value => new ReviewId(value));
            builder.Property(review => review.Rating)
                .HasConversion(rating => rating!.Value, value => Rating.Create(value).Value);

            builder.Property(review => review.Comentario)
                .HasMaxLength(200)
                .HasConversion(comentario => comentario!.value, value => new Comentario(value));

            builder.HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(review => review.VehiculoId);
            builder.HasOne<Alquiler>()
                .WithMany()
                .HasForeignKey(review => review.AlquilerId);
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(review => review.UserId);
        }
    }
}
