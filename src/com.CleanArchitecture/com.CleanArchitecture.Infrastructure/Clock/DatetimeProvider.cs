using com.CleanArchitecture.Application.Abstractions.Clock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure.Clock
{
    internal sealed class DatetimeProvider : IDatetimeProvider
    {
        public DateTime currentTime => DateTime.UtcNow;
    }
}
