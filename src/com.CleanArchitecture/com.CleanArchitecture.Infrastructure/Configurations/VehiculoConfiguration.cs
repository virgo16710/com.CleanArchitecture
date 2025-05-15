using com.CleanArchitecture.Domain.Shared;
using com.CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("vehiculos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x!.Value, value => new VehiculoId(value));
            builder.OwnsOne(x => x.Direccion);
            builder.Property(x => x.Modelo)
                .HasMaxLength(200)
                .HasConversion(modelo => modelo!.value, value => new Modelo(value));

            builder.Property(x => x.Vin)
                .HasMaxLength(500)
                .HasConversion(vin => vin!.Value, value => new Vin(value));
            builder.OwnsOne(x => x.Precio, priceBuilder =>
            {
                priceBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.OwnsOne(x=>x.Mantenimiento, priceBuilder =>
            {
                priceBuilder.Property(moneda => moneda.TipoMoneda)
                .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            builder.Property<uint>("Version").IsRowVersion();

        }
    }
}
