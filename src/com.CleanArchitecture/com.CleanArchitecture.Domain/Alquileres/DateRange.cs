using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public sealed record DateRange
    {
        private DateRange()
        {
        }

        public DateOnly Start { get; init; }
        public DateOnly End { get; init; }

        public int CantidadDias => End.DayNumber - Start.DayNumber;

        public static DateRange Create(DateOnly start, DateOnly end)
        {
            if (start > end)
            {
                throw new ApplicationException("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }
            return new DateRange
            {
                Start = start,
                End = end
            };
        }
    }
}
