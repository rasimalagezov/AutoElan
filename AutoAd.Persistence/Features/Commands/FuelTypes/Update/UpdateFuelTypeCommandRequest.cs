using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Update
{
    public class UpdateFuelTypeCommandRequest : IRequest<UpdateFuelTypeCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
