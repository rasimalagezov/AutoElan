using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Delete
{
    public class DeleteModelCommandRequest : IRequest<DeleteModelCommandResponse>
    {
        public int Id { get; set; }
    }
}
