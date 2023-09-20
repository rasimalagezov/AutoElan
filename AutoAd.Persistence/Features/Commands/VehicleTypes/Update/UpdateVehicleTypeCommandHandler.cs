using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Update
{
    public class UpdateVehicleTypeCommandHandler : IRequestHandler<UpdateVehicleTypeCommandRequest, UpdateVehicleTypeCommandResponse>
    {
        private readonly IVehicleTypeWriteRepository _vehicleTypeWriteRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleTypeCommandHandler(IVehicleTypeWriteRepository vehicleTypeWriteRepository, IMapper mapper)
        {
            _vehicleTypeWriteRepository = vehicleTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateVehicleTypeCommandResponse> Handle(UpdateVehicleTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(new VehicleTypeDto
                {
                    Id = request.Id,
                    Name = request.Name
                });
                _vehicleTypeWriteRepository.Update(vehicleType);
                await _vehicleTypeWriteRepository.SaveAsync();

                return new UpdateVehicleTypeCommandResponse()
                {
                    Result = _mapper.Map<VehicleTypeDto>(vehicleType)
                };
            }
            catch (Exception ex)
            {
                return new UpdateVehicleTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
