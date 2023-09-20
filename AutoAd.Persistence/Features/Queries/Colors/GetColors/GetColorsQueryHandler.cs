using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Features.Queries.Brands.GetBrands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Colors.GetColors
{
    public class GetColorsQueryHandler : IRequestHandler<GetColorsQueryRequest, GetColorsQueryResponse>
    {
        private readonly IColorReadRepository _colorReadRepository;
        private readonly IMapper _mapper;

        public GetColorsQueryHandler(IColorReadRepository colorReadRepository, IMapper mapper)
        {
            _colorReadRepository = colorReadRepository;
            _mapper = mapper;
        }

        public async Task<GetColorsQueryResponse> Handle(GetColorsQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Color> objList = _colorReadRepository.GetAll(false);
                return new GetColorsQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<ColorDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetColorsQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
