using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Colors.GetColorById
{
    public class GetColorByIdQueryRequest : IRequest<GetColorByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
