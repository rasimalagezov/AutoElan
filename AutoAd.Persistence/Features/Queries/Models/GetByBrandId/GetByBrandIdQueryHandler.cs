using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Models.GetByBrandId
{
    public class GetByBrandIdQueryHandler : IRequestHandler<GetByBrandIdQueryRequest, GetByBrandIdQueryResponse>
    {
        private readonly IModelReadRepository _modelReadRepository;
        private readonly IMapper _mapper;

        public GetByBrandIdQueryHandler(IModelReadRepository modelReadRepository, IMapper mapper)
        {
            _modelReadRepository = modelReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByBrandIdQueryResponse> Handle(GetByBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Model> objList = _modelReadRepository.GetWhere(m => m.BrandId == request.Id)
                    .Include(m => m.Brand);
                return new GetByBrandIdQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<ModelDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetByBrandIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
