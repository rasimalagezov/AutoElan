using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Delete
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommandRequest, DeleteVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;
        private readonly IVehicleReadRepository _vehicleReadRepository;

        public DeleteVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository, IVehicleReadRepository vehicleReadRepository)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
            _vehicleReadRepository = vehicleReadRepository;
        }

        public async Task<DeleteVehicleCommandResponse> Handle(DeleteVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Vehicle obj = await _vehicleReadRepository.GetSingleAsync(v => v.Id == request.Id);
                if (!string.IsNullOrEmpty(obj.ImageLocalPath))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.ImageLocalPath);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _vehicleWriteRepository.Remove(obj);
                await _vehicleWriteRepository.SaveAsync();

                return new DeleteVehicleCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteVehicleCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
