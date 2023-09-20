using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Update
{
    public class UpdateFuelTypeCommandHandler : IRequestHandler<UpdateFuelTypeCommandRequest, UpdateFuelTypeCommandResponse>
    {
        private readonly IFuelTypeWriteRepository _fuelTypeWriteRepository;
        private readonly IMapper _mapper;

        public UpdateFuelTypeCommandHandler(IFuelTypeWriteRepository fuelTypeWriteRepository, IMapper mapper)
        {
            _fuelTypeWriteRepository = fuelTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateFuelTypeCommandResponse> Handle(UpdateFuelTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FuelType fuelType = _mapper.Map<FuelType>(new FuelTypeDto
                {
                    Id = request.Id,
                    Name = request.Name
                });
                _fuelTypeWriteRepository.Update(fuelType);
                await _fuelTypeWriteRepository.SaveAsync();

                return new UpdateFuelTypeCommandResponse()
                {
                    Result = _mapper.Map<FuelTypeDto>(fuelType)
                };
            }
            catch (Exception ex)
            {
                return new UpdateFuelTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
