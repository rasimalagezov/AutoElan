using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Models.GetModels
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQueryRequest, GetModelsQueryResponse>
    {
        private readonly IModelReadRepository _modelReadRepository;
        private readonly IMapper _mapper;

        public GetModelsQueryHandler(IModelReadRepository modelReadRepository, IMapper mapper)
        {
            _modelReadRepository = modelReadRepository;
            _mapper = mapper;
        }

        public async Task<GetModelsQueryResponse> Handle(GetModelsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Model> objList = _modelReadRepository.GetAll(false).Include(m => m.Brand);
                return new GetModelsQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<ModelDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetModelsQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
