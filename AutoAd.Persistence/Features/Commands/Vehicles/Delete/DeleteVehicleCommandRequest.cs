using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Delete
{
    public class DeleteVehicleCommandRequest : IRequest<DeleteVehicleCommandResponse>
    {
        public int Id { get; set; }
    }
}
