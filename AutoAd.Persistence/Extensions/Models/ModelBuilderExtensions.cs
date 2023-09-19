using AutoAd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.Persistence.Extensions.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasData(
                new Brand { Id = 1, Name = "BMW"},
                new Brand { Id = 2, Name = "Mercedes"},
                new Brand { Id = 3, Name = "Audi"},
                new Brand { Id = 4, Name = "Toyota"},
                new Brand { Id = 5, Name = "Hyundai"}
                );

            modelBuilder.Entity<Model>()
                .HasData(
                new Model { Id = 1, Name = "X5", BrandId = 1},
                new Model { Id = 2, Name = "325", BrandId = 1 },
                new Model { Id = 3, Name = "E220", BrandId = 2 },
                new Model { Id = 4, Name = "S300", BrandId = 2 },
                new Model { Id = 5, Name = "C230", BrandId = 2 },
                new Model { Id = 6, Name = "Q5", BrandId = 3 },
                new Model { Id = 7, Name = "Q7", BrandId = 3 },
                new Model { Id = 8, Name = "Land Cruiser", BrandId = 4 },
                new Model { Id = 9, Name = "Prius", BrandId = 4 },
                new Model { Id = 10, Name = "Sonata", BrandId = 5 },
                new Model { Id = 11, Name = "Accent", BrandId = 5 }
                );

            modelBuilder.Entity<Color>()
                .HasData(
                new Color { Id = 1, Name = "Red" },
                new Color { Id = 2, Name = "White" },
                new Color { Id = 3, Name = "Blue" },
                new Color { Id = 4, Name = "Black" },
                new Color { Id = 5, Name = "Green" }
                );

            modelBuilder.Entity<VehicleType>()
                .HasData(
                new VehicleType { Id = 1, Name = "Sedan" },
                new VehicleType { Id = 2, Name = "Ofroader" },
                new VehicleType { Id = 3, Name = "Bus" }
                );

            modelBuilder.Entity<FuelType>()
                .HasData(
                new FuelType { Id = 1, Name = "Benzin" },
                new FuelType { Id = 2, Name = "Dizel" },
                new FuelType { Id = 3, Name = "Hibrit" },
                new FuelType { Id = 4, Name = "Elektrik" }
                );

            modelBuilder.Entity<Gearbox>()
                .HasData(
                new Gearbox { Id = 1, Name = "Avtomat" },
                new Gearbox { Id = 2, Name = "Mexanika" },
                new Gearbox { Id = 3, Name = "Tiptronic" }
                );
        }
    }
}
