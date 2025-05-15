using com.CleanArchitecture.Application.Abstractions.Clock;
using com.CleanArchitecture.Application.Abstractions.Messaging;
using com.CleanArchitecture.Application.Exceptions;
using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Users;
using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Application.Alquileres.ReservarAlquiler
{
    internal sealed class ReservarAlquilerCommandHandler :
        ICommandHandler<ReservarAlquilerCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly PrecioService _precioService;
        private readonly IDatetimeProvider _datetimeProvider;
        private readonly IUnitOfWork _unitOfWork;

        public ReservarAlquilerCommandHandler(
            IUserRepository userRepository,
            IVehiculoRepository vehiculoRepository,
            IAlquilerRepository alquilerRepository,
            PrecioService precioService,
            IDatetimeProvider datetimeProvider,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _vehiculoRepository = vehiculoRepository;
            _alquilerRepository = alquilerRepository;
            _precioService = precioService;
            _datetimeProvider = datetimeProvider;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(
            ReservarAlquilerCommand request,
            CancellationToken cancellationToken)
        {
            var userId = new UserId(request.UserId);
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            if (user is null) return Result.Failure<Guid>(UserErrors.NotFound);
            var vehiculoId = new VehiculoId(request.VehiculoId);
            var vehiculo = await _vehiculoRepository.GetByIdAsync( vehiculoId, cancellationToken);
            if (vehiculo is null) return Result.Failure<Guid>(VehiculoErrors.NotFound);
            var duracion = DateRange.Create(request.Start, request.End);
            if (await _alquilerRepository.IsOverlappingAsync(vehiculo, duracion, cancellationToken))
                return Result.Failure<Guid>(AlquilerErrors.Overlap);
            try
            {
                var alquiler = Alquiler.Reservar(
                    vehiculo,
                    user.Id!,
                    duracion,
                    _datetimeProvider.currentTime,
                    _precioService
                    );
                _alquilerRepository.Add(alquiler);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                return alquiler!.Id!.Value;
            }
            catch(ConcurrencyException)
            {
                return Result.Failure<Guid>(AlquilerErrors.Overlap);
            }
        }
    }
}
