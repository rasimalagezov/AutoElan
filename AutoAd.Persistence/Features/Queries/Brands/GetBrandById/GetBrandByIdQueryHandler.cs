using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.Brands.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQueryRequest, GetBrandByIdQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _mapper = mapper;
        }

        public async Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Brand obj = await _brandReadRepository.GetByIdAsync(request.Id);
                return new GetBrandByIdQueryResponse()
                {
                    Result = _mapper.Map<BrandDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetBrandByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
