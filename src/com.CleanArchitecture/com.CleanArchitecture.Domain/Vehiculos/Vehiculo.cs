using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Shared;

namespace com.CleanArchitecture.Domain.Vehiculos;

public sealed class Vehiculo : Entity
{
    private Vehiculo() { }
    public Vehiculo(
        Guid id,
        Modelo modelo,
        Vin vin,
        Direccion direccion,
        Moneda precio,
        Moneda mantenimiento,
        DateTime fechaUltimoAlquiler,
        List<Accesorios> accesorios) : base(id)
    {
        Modelo = modelo;
        Vin = vin;
        Direccion = direccion;
        Precio = precio;
        Mantenimiento = mantenimiento;
        FechaUltimaAlquiler = fechaUltimoAlquiler;
        this.Accesorios = accesorios;
    }
    public Modelo? Modelo { get; private set; }
    public Vin? Vin{get; private set;}
    public Direccion? Direccion { get; private set; }
    public Moneda? Precio { get; private set; }
    public Moneda? Mantenimiento{get; private set;}
    public DateTime? FechaUltimaAlquiler{get; internal set;}
    public List<Accesorios>? Accesorios{get; private set;}
    

}

