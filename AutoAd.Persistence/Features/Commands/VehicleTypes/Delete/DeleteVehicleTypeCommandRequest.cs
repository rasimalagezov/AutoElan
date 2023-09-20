using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Delete
{
    public class DeleteVehicleTypeCommandRequest : IRequest<DeleteVehicleTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
