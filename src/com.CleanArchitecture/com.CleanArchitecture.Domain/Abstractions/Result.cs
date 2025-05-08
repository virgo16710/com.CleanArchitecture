using System.Diagnostics.CodeAnalysis;

namespace com.CleanArchitecture.Domain.Abstractions
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException("No puede ser un exito y tener un error");
            }
            if (!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException("No puede ser un error y no tener un error");
            }
            IsSuccess = isSuccess;
            Error = error;
        }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        //esto es un succes object
        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);
        public static Result<TValue> Succes<TValue>(TValue value)
            => new Result<TValue>(value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error error)
            => new Result<TValue>(default, false, error);
        public static Result<TValue> Create<TValue>(TValue value)
            => value is not null
            ? Succes(value)
            : Failure<TValue>(Error.NullValue);

    }
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;
        protected internal Result(TValue? value, bool isSucces, Error error) : base(isSucces, error)
        {
            _value = value;
        }
        [NotNull]
        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("El resultado del valor de error no es admisible");

        //Es como enseñarle a .NET a hacer "traducciones" sin que tú tengas que pedirle explícitamente "oye, convierte esto".
        public static implicit operator Result<TValue>(TValue value) => Create(value);


    }
}
