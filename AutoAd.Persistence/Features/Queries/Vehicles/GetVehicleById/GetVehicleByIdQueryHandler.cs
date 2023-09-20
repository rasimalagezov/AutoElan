using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Vehicles.GetVehicleById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQueryRequest, GetVehicleByIdQueryResponse>
    {
        private readonly IVehicleReadRepository _vehicleReadRepository;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(IVehicleReadRepository vehicleReadRepository, IMapper mapper)
        {
            _vehicleReadRepository = vehicleReadRepository;
            _mapper = mapper;
        }

        public async Task<GetVehicleByIdQueryResponse> Handle(GetVehicleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Vehicle obj = await _vehicleReadRepository.GetWhere(m => m.Id == request.Id)
                    .Include(m => m.Brand)
                    .Include(m => m.Model)
                    .Include(c => c.Color)
                    .Include(vt => vt.VehicleType)
                    .Include(ft => ft.FuelType)
                    .Include(g => g.Gearbox)
                    .FirstOrDefaultAsync();
                return new GetVehicleByIdQueryResponse()
                {
                    Result = _mapper.Map<VehicleDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetVehicleByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
