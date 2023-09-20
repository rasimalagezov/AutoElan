using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Create
{
    public class CreateGearboxCommandRequest : IRequest<CreateGearboxCommandResponse>
    {
        public string Name { get; set; }
    }
}
