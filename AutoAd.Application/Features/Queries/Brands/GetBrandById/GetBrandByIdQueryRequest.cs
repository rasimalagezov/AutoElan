﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Application.Features.Queries.Brands.GetBrandById
{
    public class GetBrandByIdQueryRequest : IRequest<GetBrandByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
