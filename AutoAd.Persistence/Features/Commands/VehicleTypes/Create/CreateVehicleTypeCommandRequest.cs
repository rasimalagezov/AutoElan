using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Create
{
    public class CreateVehicleTypeCommandRequest : IRequest<CreateVehicleTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
