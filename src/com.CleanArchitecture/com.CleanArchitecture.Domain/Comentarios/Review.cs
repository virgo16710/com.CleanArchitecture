using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Comentarios.Events;

namespace com.CleanArchitecture.Domain.Comentarios
{
    public sealed class Review :Entity
    {
        private Review() { }
        private  Review(
            Guid id, 
            Guid vehiculoId, 
            Guid alquilerId,
            Guid userId,
            Rating rating,
            Comentario comentario,
            DateTime fechaCreacion) : base(id)
        {
            Id = id;
            VehiculoId = vehiculoId;
            AlquilerId = alquilerId;
            UserId = userId;
            Rating = rating;
            Comentario = comentario;
            FechaCreacion = fechaCreacion;
        }
        public Guid VehiculoId { get; private set; }
        public Guid AlquilerId { get; private set; }
        public Guid UserId { get; private set; }
        public Rating Rating { get; private set; }
        public Comentario Comentario { get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public static Result<Review> Create(
            Alquiler alquiler,
            Rating rating,
            Comentario comentario,
            DateTime fechaCreacion)
        {
            if(alquiler.Status != AlquilerStatus.Completado)
            {
                return Result.Failure<Review>(ComentarioError.NotEligible);
            }
            var review = new Review(
                Guid.NewGuid(),
                alquiler.VehiculoId,
                alquiler.Id,
                alquiler.UserId,
                rating,
                comentario,
                fechaCreacion);
            review.RaiseDomainEvent(new ComentarioCreateDomainEvent(review.Id));
            return review;

        }
    }
}
