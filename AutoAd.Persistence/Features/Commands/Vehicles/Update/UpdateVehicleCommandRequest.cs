using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Update
{
    public class UpdateVehicleCommandRequest : IRequest<UpdateVehicleCommandResponse>
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public long Price { get; set; }
        public int ColorId { get; set; }
        public int VehicleTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearboxId { get; set; }
        public string? PhotoUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }
    }
}
