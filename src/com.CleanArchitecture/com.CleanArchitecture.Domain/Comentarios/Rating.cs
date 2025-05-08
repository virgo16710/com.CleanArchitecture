using com.CleanArchitecture.Domain.Abstractions;

namespace com.CleanArchitecture.Domain.Comentarios
{
    public sealed record Rating
    {
        public static readonly Error Invalid = new("Rating.Invalid", "El valor de la calificación debe estar entre 1 y 5.");
        public int Value { get; init; }
        private Rating(int value) => Value = value;
        public static Result<Rating> Create(int value)
        {
            if (value < 1 || value > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }
            return new Rating(value);
        }
    }
}
