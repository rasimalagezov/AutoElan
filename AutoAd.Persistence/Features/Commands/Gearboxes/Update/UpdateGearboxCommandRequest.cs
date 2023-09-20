using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Update
{
    public class UpdateGearboxCommandRequest : IRequest<UpdateGearboxCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
