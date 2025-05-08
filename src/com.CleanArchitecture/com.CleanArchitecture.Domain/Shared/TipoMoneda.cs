namespace com.CleanArchitecture.Domain.Shared
{
    public record TipoMoneda
    {
        public static readonly TipoMoneda NONE = new("");
        public static readonly TipoMoneda CLP = new("CLP");
        public static readonly TipoMoneda EUR = new("EUR");
        public static readonly TipoMoneda USD = new("USD");
        public static readonly TipoMoneda ARS = new("ARS");
        private TipoMoneda(string codigo) => Codigo = codigo;
        public string? Codigo { get; init; }
        public static readonly IReadOnlyCollection<TipoMoneda> ALL = new[]
        {
            CLP,
            EUR,
            USD,
            ARS
        };
        public static TipoMoneda FromCodigo(string codigo)
        {
            return ALL.FirstOrDefault(x => x.Codigo == codigo) ?? 
                throw new ApplicationException("El tipo de moneda es invalido");
        }
    }
}
