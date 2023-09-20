using MediatR;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Delete
{
    public class DeleteFuelTypeCommandRequest : IRequest<DeleteFuelTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
