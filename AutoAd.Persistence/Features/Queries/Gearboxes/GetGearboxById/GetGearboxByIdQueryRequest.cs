using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxById
{
    public class GetGearboxByIdQueryRequest : IRequest<GetGearboxByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
