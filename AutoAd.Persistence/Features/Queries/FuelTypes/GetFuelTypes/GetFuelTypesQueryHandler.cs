using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Features.Queries.Colors.GetColors;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypes
{
    public class GetFuelTypesQueryHandler : IRequestHandler<GetFuelTypesQueryRequest, GetFuelTypesQueryResponse>
    {
        private readonly IFuelTypeReadRepository _fuelTypeReadRepository;
        private readonly IMapper _mapper;

        public GetFuelTypesQueryHandler(IFuelTypeReadRepository fuelTypeReadRepository, IMapper mapper)
        {
            _fuelTypeReadRepository = fuelTypeReadRepository;
            _mapper = mapper;
        }

        public async Task<GetFuelTypesQueryResponse> Handle(GetFuelTypesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<FuelType> objList = _fuelTypeReadRepository.GetAll(false);
                return new GetFuelTypesQueryResponse()
                {
                    Result = _mapper.Map<IEnumerable<FuelTypeDto>>(objList)
                };
            }
            catch (Exception ex)
            {
                return new GetFuelTypesQueryResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
