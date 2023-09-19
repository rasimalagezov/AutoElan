using AutoAd.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public long Price { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int FuelTypeId { get; set; }
        public virtual FuelType FuelType { get; set; }
        public int GearboxId { get; set; }
        public virtual Gearbox Gearbox { get; set;}
        public string? PhotoUrl { get; set; }
        public string? ImageLocalPath { get; set; }
    }
}
