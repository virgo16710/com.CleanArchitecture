using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Abstractions
{
    public record Error(string Code, string Name)
    {
        public static Error None = new Error(string.Empty, string.Empty);
        public static Error NullValue = new("Error.NullValue", "Un valor Null fue ingresado");
    }
}
