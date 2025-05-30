﻿using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Alquileres.Events;
using com.CleanArchitecture.Domain.Shared;
using com.CleanArchitecture.Domain.Users;
using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public sealed class Alquiler : Entity<AlquilerId>
    {
        private Alquiler() { }
        private Alquiler(
            AlquilerId id,
            VehiculoId vehiculoId,
            UserId userId,
            DateRange duracion,
            Moneda precioPorPeriodo,
            Moneda precioMantenimiento,
            Moneda accesorios,
            Moneda precioTotal,
            AlquilerStatus status,
            DateTime fechaCreacion
            ) : base(id)
        {
            Id = id;
            UserId = userId;
            VehiculoId = vehiculoId;
            Duracion = duracion;
            PrecioPorPeriodo = precioPorPeriodo;
            PrecioMantenimiento = precioMantenimiento;
            Accesorios = accesorios;
            Status = status;
            PrecioTotal = precioTotal;
            FechaCreacion = fechaCreacion;

        }
        public UserId? UserId { get; private set; }
        public VehiculoId? VehiculoId { get; private set; }
        public AlquilerStatus Status { get; private set; }
        public DateRange? Duracion { get; private set; }
        public Moneda? PrecioPorPeriodo { get; private set; }
        public Moneda? PrecioMantenimiento { get; private set; }
        public Moneda? Accesorios { get; private set; }
        public Moneda? PrecioTotal { get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? Denegacion { get; private set; }
        public DateTime? FechaCompletado { get; private set; }
        public DateTime? FechaCancelado { get; private set; }
        public static Alquiler Reservar(
            Vehiculo vehiculo,
            UserId userId,
            DateRange duracion,
            DateTime fechaCreacion,
            PrecioService precioService)
        {
            var precioDetalle = precioService.CalcularPrecio(vehiculo, duracion);
            var alquiler = new Alquiler(
                AlquilerId.New(),
                vehiculo.Id!, 
                userId, 
                duracion, 
                precioDetalle.PrecioPorPeriodo, 
                precioDetalle.Mantenimiento,
                precioDetalle.Accesorios,
                precioDetalle.PrecioTotal,
                AlquilerStatus.Reservado,
                fechaCreacion);
            alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id!));
            vehiculo.FechaUltimaAlquiler = fechaCreacion;
            return alquiler;
        }
        //Este result lo construyes tu mismo
        public Result Confirmar(DateTime utcNow)
        {
            if(Status != AlquilerStatus.Reservado )
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }
            Status = AlquilerStatus.Confirmado;
            FechaConfirmacion = utcNow;
            RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id!));
            return Result.Success();
        }

        public Result Rechazar(DateTime utcNow)
        {
            if(Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }
            Status = AlquilerStatus.Rechazado;
            Denegacion = utcNow;
            RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id!));
            return Result.Success();
        }
        public Result Cancelar(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }

            var currentDate = DateOnly.FromDateTime(utcNow);
            if(currentDate > Duracion!.Start)
            {
                return Result.Failure(AlquilerErrors.AlreadyStarted);
            }

            Status = AlquilerStatus.Cancelado;
            FechaCancelado = utcNow;
            RaiseDomainEvent(new AlquilerCanceladoDomainEvent(Id!));
            return Result.Success();
        }
        public Result Completado(DateTime utcNow)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }
            Status = AlquilerStatus.Completado;
            FechaCompletado = utcNow;
            RaiseDomainEvent(new AlquilerCompletadoDomainEvent(Id!));
            return Result.Success();
        }
    }
}
