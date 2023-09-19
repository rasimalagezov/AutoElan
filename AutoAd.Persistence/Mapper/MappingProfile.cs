using AutoAd.Application.DTO;
using AutoAd.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Persistence.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, VehicleDto>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<FuelType, FuelTypeDto>().ReverseMap();
            CreateMap<Gearbox, GearboxDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
        }
    }
}
