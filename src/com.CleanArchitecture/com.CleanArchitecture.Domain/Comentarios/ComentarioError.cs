using com.CleanArchitecture.Domain.Abstractions;

namespace com.CleanArchitecture.Domain.Comentarios
{
    public static class ComentarioError
    {
        public static Error NotEligible = new Error(
            "Comentario.NotEligible",
            "El comentario y calificacion para el auto no es elegible por que aun no se completa el servicio");
    }
}
