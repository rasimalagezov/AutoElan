using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Colors.Delete
{
    public class DeleteColorCommandRequest : IRequest<DeleteColorCommandResponse>
    {
        public int Id { get; set; }
    }
}
