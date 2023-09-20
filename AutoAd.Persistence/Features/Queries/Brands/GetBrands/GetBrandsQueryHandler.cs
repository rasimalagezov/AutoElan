using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Queries.Brands.GetBrands
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQueryRequest, GetBrandsQueryResponse>
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IMapper _mapper;

        public GetBrandsQueryHandler(IBrandReadRepository brandReadRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _mapper = mapper;
        }

        public async Task<GetBrandsQueryResponse> Handle(GetBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Brand> objList =  _brandReadRepository.GetAll(false);
                return new GetBrandsQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<BrandDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetBrandsQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
