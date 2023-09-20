using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxes
{
    public class GetGearboxesQueryHandler : IRequestHandler<GetGearboxesQueryRequest, GetGearboxesQueryResponse>
    {
        private readonly IGearboxReadRepository _gearboxReadRepository;
        private readonly IMapper _mapper;

        public GetGearboxesQueryHandler(IGearboxReadRepository gearboxReadRepository, IMapper mapper)
        {
            _gearboxReadRepository = gearboxReadRepository;
            _mapper = mapper;
        }

        public async Task<GetGearboxesQueryResponse> Handle(GetGearboxesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Gearbox> objList = _gearboxReadRepository.GetAll(false);
                return new GetGearboxesQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<GearboxDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetGearboxesQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
