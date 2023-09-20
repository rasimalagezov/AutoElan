using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Create
{
    public class CreateFuelTypeCommandHandler : IRequestHandler<CreateFuelTypeCommandRequest, CreateFuelTypeCommandResponse>
    {
        private readonly IFuelTypeWriteRepository _fuelTypeWriteRepository;
        private readonly IMapper _mapper;

        public CreateFuelTypeCommandHandler(IFuelTypeWriteRepository fuelTypeWriteRepository, IMapper mapper)
        {
            _fuelTypeWriteRepository = fuelTypeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateFuelTypeCommandResponse> Handle(CreateFuelTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FuelType fuelType = _mapper.Map<FuelType>(new FuelTypeDto
                {
                    Name = request.Name
                });
                await _fuelTypeWriteRepository.AddAsync(fuelType);
                await _fuelTypeWriteRepository.SaveAsync();

                return new CreateFuelTypeCommandResponse()
                {
                    Result = _mapper.Map<FuelTypeDto>(fuelType)
                };
            }
            catch (Exception ex)
            {
                return new CreateFuelTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
