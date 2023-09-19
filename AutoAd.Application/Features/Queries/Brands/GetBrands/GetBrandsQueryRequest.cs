using AutoAd.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Application.Features.Queries.Brands.GetBrands
{
    public class GetBrandsQueryRequest : IRequest<GetBrandsQueryResponse>
    {
    }
}
