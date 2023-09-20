using AutoAd.Application.Repositories.VehicleTypeRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Delete
{
    public class DeleteVehicleTypeCommandHandler : IRequestHandler<DeleteVehicleTypeCommandRequest, DeleteVehicleTypeCommandResponse>
    {
        private readonly IVehicleTypeWriteRepository _vehicleTypeWriteRepository;

        public DeleteVehicleTypeCommandHandler(IVehicleTypeWriteRepository vehicleTypeWriteRepository)
        {
            _vehicleTypeWriteRepository = vehicleTypeWriteRepository;
        }

        public async Task<DeleteVehicleTypeCommandResponse> Handle(DeleteVehicleTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _vehicleTypeWriteRepository.RemoveAsync(request.Id);
                await _vehicleTypeWriteRepository.SaveAsync();

                return new DeleteVehicleTypeCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteVehicleTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
