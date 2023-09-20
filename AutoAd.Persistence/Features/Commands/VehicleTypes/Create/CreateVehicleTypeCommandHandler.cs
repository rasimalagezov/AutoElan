using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Create
{
    public class CreateVehicleTypeCommandHandler : IRequestHandler<CreateVehicleTypeCommandRequest, CreateVehicleTypeCommandResponse>
    {
        private readonly IVehicleTypeWriteRepository _vehicleTypeWriteRepository;
        private readonly IMapper _mapper;

        public CreateVehicleTypeCommandHandler(IVehicleTypeWriteRepository vehicleTypeWriteRepository, IMapper mapper)
        {
            _vehicleTypeWriteRepository = vehicleTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateVehicleTypeCommandResponse> Handle(CreateVehicleTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(new VehicleTypeDto
                {
                    Name = request.Name
                });
                await _vehicleTypeWriteRepository.AddAsync(vehicleType);
                await _vehicleTypeWriteRepository.SaveAsync();

                return new CreateVehicleTypeCommandResponse()
                {
                    Result = _mapper.Map<VehicleTypeDto>(vehicleType)
                };
            }
            catch (Exception ex)
            {
                return new CreateVehicleTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
