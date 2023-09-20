using MediatR;

namespace AutoAd.Persistence.Features.Commands.VehicleTypes.Update
{
    public class UpdateVehicleTypeCommandRequest : IRequest<UpdateVehicleTypeCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
