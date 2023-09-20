using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Create
{
    public class CreateVehicleCommandRequest : IRequest<CreateVehicleCommandResponse>
    {
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public long Price { get; set; }
        public int ColorId { get; set; }
        public int VehicleTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearboxId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
