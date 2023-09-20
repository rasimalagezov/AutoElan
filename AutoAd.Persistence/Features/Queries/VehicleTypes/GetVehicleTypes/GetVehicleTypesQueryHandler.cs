using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypes
{
    public class GetVehicleTypesQueryHandler : IRequestHandler<GetVehicleTypesQueryRequest, GetVehicleTypesQueryResponse>
    {
        private readonly IVehicleTypeReadRepository _vehicleTypeReadRepository;
        private readonly IMapper _mapper;

        public GetVehicleTypesQueryHandler(IVehicleTypeReadRepository vehicleTypeReadRepository, IMapper mapper)
        {
            _vehicleTypeReadRepository = vehicleTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetVehicleTypesQueryResponse> Handle(GetVehicleTypesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<VehicleType> objList = _vehicleTypeReadRepository.GetAll(false);
                return new GetVehicleTypesQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<VehicleTypeDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetVehicleTypesQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
