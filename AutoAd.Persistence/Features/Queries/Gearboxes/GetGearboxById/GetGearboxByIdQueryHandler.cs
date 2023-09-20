using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypeById;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxById
{
    public class GetGearboxByIdQueryHandler : IRequestHandler<GetGearboxByIdQueryRequest, GetGearboxByIdQueryResponse>
    {
        private readonly IGearboxReadRepository _gearboxReadRepository;
        private readonly IMapper _mapper;

        public GetGearboxByIdQueryHandler(IGearboxReadRepository gearboxReadRepository, IMapper mapper)
        {
            _gearboxReadRepository = gearboxReadRepository;
            _mapper = mapper;
        }

        public async Task<GetGearboxByIdQueryResponse> Handle(GetGearboxByIdQueryRequest request, CancellationToken cancellationToken)
        {

            try
            {
                Gearbox obj = await _gearboxReadRepository.GetByIdAsync(request.Id);
                return new GetGearboxByIdQueryResponse()
                {
                    Result = _mapper.Map<GearboxDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetGearboxByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
