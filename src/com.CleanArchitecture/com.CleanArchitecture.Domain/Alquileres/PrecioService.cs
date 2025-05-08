using com.CleanArchitecture.Domain.Shared;
using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public class PrecioService
    {
        public PrecioDetalle CalcularPrecio(Vehiculo vehiculo, DateRange periodo)
        {
            var tipoMoneda = vehiculo.Precio!.TipoMoneda;
            var precioPorPeriodo = new Moneda(periodo.CantidadDias*vehiculo.Precio.Monto, tipoMoneda);
            decimal porcentageChange = 0;
            foreach(var accesorio in vehiculo.Accesorios!)
            {
               porcentageChange += accesorio switch
               {
                   Accesorios.AppleCar or Accesorios.AndroidCar => 0.05m,
                   Accesorios.AireAcondicionado => 0.01m,
                   Accesorios.Mapas => 0.01m,
                   _ => 0
               };

            }
            var accesorioCharges = Moneda.Zero(tipoMoneda);
            if(porcentageChange > 0)
            {
                accesorioCharges = new Moneda(precioPorPeriodo.Monto * porcentageChange, tipoMoneda);
            }
            var precioTotal = Moneda.Zero();
            precioTotal += precioPorPeriodo;
            if(!vehiculo!.Mantenimiento!.IsZero())
            {
                precioTotal += vehiculo.Mantenimiento;
            }
            precioTotal += accesorioCharges;

            return new PrecioDetalle(precioPorPeriodo,
                vehiculo.Mantenimiento,
                accesorioCharges,
                precioTotal
                );
        }
    }
}
