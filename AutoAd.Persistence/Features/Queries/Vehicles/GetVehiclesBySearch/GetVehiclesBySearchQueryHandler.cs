using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehiclesBySearch
{
    public class GetVehiclesBySearchQueryHandler : IRequestHandler<GetVehiclesBySearchQueryRequest, GetVehiclesBySearchQueryResponse>
    {
        private readonly IVehicleReadRepository _vehicleReadRepository;
        private readonly IMapper _mapper;

        public GetVehiclesBySearchQueryHandler(IVehicleReadRepository vehicleReadRepository, IMapper mapper)
        {
            _vehicleReadRepository = vehicleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetVehiclesBySearchQueryResponse> Handle(GetVehiclesBySearchQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Vehicle> query = _vehicleReadRepository.GetAll();
                if (!string.IsNullOrEmpty(request.BrandName))
                {
                    query = query.Where(v => v.Brand.Name == request.BrandName);
                }
                if (!string.IsNullOrEmpty(request.ModelName))
                {
                    query = query.Where(v => v.Model.Name == request.ModelName);
                }
                if (request.MinProductionYear > 0)
                {
                    query = query.Where(v => v.ProductionYear >= request.MinProductionYear);
                }
                if (request.MaxProductionYear > 0)
                {
                    query = query.Where(v => v.ProductionYear <= request.MaxProductionYear);
                }
                if (request.MinPrice > 0)
                {
                    query = query.Where(v => v.Price >= request.MinPrice);
                }
                if (request.MaxPrice > 0)
                {
                    query = query.Where(v => v.Price <= request.MaxPrice);
                }

                    query.Include(m => m.Brand)
                    .Include(m => m.Model)
                    .Include(c => c.Color)
                    .Include(vt => vt.VehicleType)
                    .Include(ft => ft.FuelType)
                    .Include(g => g.Gearbox).ToList();

                return new GetVehiclesBySearchQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<VehicleDto>>(query)
                };
            }
            catch (Exception ex)
            {
                return new GetVehiclesBySearchQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
