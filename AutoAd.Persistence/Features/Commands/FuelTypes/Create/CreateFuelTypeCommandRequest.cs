using MediatR;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Create
{
    public class CreateFuelTypeCommandRequest : IRequest<CreateFuelTypeCommandResponse>
    {
        public string Name { get; set; }
    }
}
