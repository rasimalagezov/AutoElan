using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Features.Queries.Brands.GetBrandById;
using AutoAd.Persistence.Repositories.BrandRepository;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Colors.GetColorById
{
    public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQueryRequest, GetColorByIdQueryResponse>
    {
        private readonly IColorReadRepository _colorReadRepository;
        private readonly IMapper _mapper;

        public GetColorByIdQueryHandler(IColorReadRepository colorReadRepository, IMapper mapper)
        {
            _colorReadRepository = colorReadRepository;
            _mapper = mapper;
        }

        public async Task<GetColorByIdQueryResponse> Handle(GetColorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Color obj = await _colorReadRepository.GetByIdAsync(request.Id);
                return new GetColorByIdQueryResponse()
                {
                    Result = _mapper.Map<ColorDto>(obj)
                };
            }
            catch (Exception ex)
            {
                return new GetColorByIdQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
