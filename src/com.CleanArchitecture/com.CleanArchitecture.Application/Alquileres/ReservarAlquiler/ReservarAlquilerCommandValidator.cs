using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Alquileres.ReservarAlquiler
{
    public class ReservarAlquilerCommandValidator : AbstractValidator<ReservarAlquilerCommand>
    {
        public ReservarAlquilerCommandValidator()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.VehiculoId).NotEmpty();
            RuleFor(c => c.Start).LessThan(c => c.End);

        }
    }
}
