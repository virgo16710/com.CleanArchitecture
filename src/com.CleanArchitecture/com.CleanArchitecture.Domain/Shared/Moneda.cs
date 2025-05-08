namespace com.CleanArchitecture.Domain.Shared
{
    public record Moneda(decimal Monto, TipoMoneda TipoMoneda )
    {
        public static Moneda operator +(Moneda a, Moneda b)
        {
            if(a.TipoMoneda != b.TipoMoneda)
            {
                throw new ApplicationException("No se puede sumar dos monedas de diferente tipo");
            }
            return new Moneda(a.Monto + b.Monto, a.TipoMoneda);
        }

        public static Moneda Zero() => new(0,TipoMoneda.NONE);
        public static Moneda Zero(TipoMoneda tipoMoneda) => new(0, tipoMoneda);
        public bool IsZero() => this == Zero(TipoMoneda);
    }
}
