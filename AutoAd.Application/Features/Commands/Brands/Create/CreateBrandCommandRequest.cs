using AutoAd.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Application.Features.Commands.Brands.Create
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public BrandDto brandDto { get; set; }
    }
}
