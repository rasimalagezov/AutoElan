using MediatR;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Delete
{
    public class DeleteGearboxCommandRequest : IRequest<DeleteGearboxCommandResponse>
    {
        public int Id { get; set; }
    }
}
