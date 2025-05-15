using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Shared;
using com.CleanArchitecture.Domain.Users;
using com.CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace com.CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
    {
        public void Configure(EntityTypeBuilder<Alquiler> builder)
        {
            builder.ToTable("alquileres");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x!.Value, value => new AlquilerId(value));

            builder.OwnsOne(alquiler => alquiler.PrecioPorPeriodo, PrecioBuilder =>
            {
                PrecioBuilder.Property(moneda => moneda.TipoMoneda)
               .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(alquiler => alquiler.PrecioMantenimiento, PrecioBuilder =>
            {
                PrecioBuilder.Property(moneda => moneda.TipoMoneda)
               .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(alquiler => alquiler.Accesorios, PrecioBuilder =>
            {
                PrecioBuilder.Property(moneda => moneda.TipoMoneda)
               .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(alquiler => alquiler.PrecioTotal, PrecioBuilder =>
            {
                PrecioBuilder.Property(moneda => moneda.TipoMoneda)
               .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(alquiler => alquiler.Duracion);
            builder.HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(alquiler => alquiler.VehiculoId);
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(alquiler => alquiler.UserId);
        }
    }
}
