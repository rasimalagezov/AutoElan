using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Features.Queries.Models.GetModelById
{
    public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQueryRequest, GetModelByIdQueryResponse>
    {
        private readonly IModelReadRepository _modelReadRepository;
        private readonly IMapper _mapper;

        public GetModelByIdQueryHandler(IModelReadRepository modelReadRepository, IMapper mapper)
        {
            _modelReadRepository = modelReadRepository;
            _mapper = mapper;
        }

        public async Task<GetModelByIdQueryResponse> Handle(GetModelByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Model obj = await _modelReadRepository.GetWhere(m => m.Id == request.Id)
                    .Include(m => m.Brand).FirstOrDefaultAsync();
                return new GetModelByIdQueryResponse()
                {
                    Result = _mapper.Map<ModelDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetModelByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
