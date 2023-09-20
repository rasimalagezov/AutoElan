using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypeById
{
    public class GetVehicleTypeByIdQueryHandler : IRequestHandler<GetVehicleTypeByIdQueryRequest, GetVehicleTypeByIdQueryResponse>
    {
        private readonly IVehicleTypeReadRepository _vehicleTypeReadRepository;
        private readonly IMapper _mapper;

        public GetVehicleTypeByIdQueryHandler(IVehicleTypeReadRepository vehicleTypeReadRepository, IMapper mapper)
        {
            _vehicleTypeReadRepository = vehicleTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetVehicleTypeByIdQueryResponse> Handle(GetVehicleTypeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                VehicleType obj = await _vehicleTypeReadRepository.GetByIdAsync(request.Id);
                return new GetVehicleTypeByIdQueryResponse()
                {
                    Result = _mapper.Map<VehicleTypeDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetVehicleTypeByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
