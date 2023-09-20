using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypeById
{
    public class GetFuelTypeByIdQueryRequest : IRequest<GetFuelTypeByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
