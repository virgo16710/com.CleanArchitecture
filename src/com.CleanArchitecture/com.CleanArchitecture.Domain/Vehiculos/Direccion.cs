using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Vehiculos
{
    public record Direccion
    (
        string Pais,
        string Departamento,
        string Provincia,
        string Ciudad,
        string Calle
     );
    
}
