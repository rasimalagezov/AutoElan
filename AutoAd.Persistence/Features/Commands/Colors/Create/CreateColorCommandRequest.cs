using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Colors.Create
{
    public class CreateColorCommandRequest : IRequest<CreateColorCommandResponse>
    {
        public string Name { get; set; }
    }
}
