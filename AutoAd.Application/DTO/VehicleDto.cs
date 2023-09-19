using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutoAd.Application.DTO
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public BrandDto? Brand { get; set; }
        public int ModelId { get; set; }
        public ModelDto? Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public long Price { get; set; }
        public int ColorId { get; set; }
        public ColorDto? Color { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleTypeDto? VehicleType { get; set; }
        public int FuelTypeId { get; set; }
        public FuelTypeDto? FuelType { get; set; }
        public int GearboxId { get; set; }
        public GearboxDto? Gearbox { get; set; }
        public string? PhotoUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }
    }
}
