using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypeById
{
    public class GetFuelTypeByIdQueryHandler : IRequestHandler<GetFuelTypeByIdQueryRequest, GetFuelTypeByIdQueryResponse>
    {
        private readonly IFuelTypeReadRepository _fuelTypeReadRepository;
        private readonly IMapper _mapper;

        public GetFuelTypeByIdQueryHandler(IFuelTypeReadRepository fuelTypeReadRepository, IMapper mapper)
        {
            _fuelTypeReadRepository = fuelTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetFuelTypeByIdQueryResponse> Handle(GetFuelTypeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                FuelType obj = await _fuelTypeReadRepository.GetByIdAsync(request.Id);
                return new GetFuelTypeByIdQueryResponse()
                {
                    Result = _mapper.Map<FuelTypeDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetFuelTypeByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
