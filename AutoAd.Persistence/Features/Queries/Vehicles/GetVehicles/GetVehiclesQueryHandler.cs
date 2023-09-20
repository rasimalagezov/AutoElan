using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehicles
{
    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQueryRequest, GetVehiclesQueryResponse>
    {
        private readonly IVehicleReadRepository _vehicleReadRepository;
        private readonly IMapper _mapper;

        public GetVehiclesQueryHandler(IVehicleReadRepository vehicleReadRepository, IMapper mapper)
        {
            _vehicleReadRepository = vehicleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetVehiclesQueryResponse> Handle(GetVehiclesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Vehicle> objList = _vehicleReadRepository.GetAll(false)
                    .Include(m => m.Brand)
                    .Include(m => m.Model)
                    .Include(c => c.Color)
                    .Include(vt => vt.VehicleType)
                    .Include(ft => ft.FuelType)
                    .Include(g => g.Gearbox).ToList();

                return new GetVehiclesQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<VehicleDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetVehiclesQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
