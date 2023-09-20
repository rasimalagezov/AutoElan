using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Update
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommandRequest, UpdateVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<UpdateVehicleCommandResponse> Handle(UpdateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(new VehicleDto
                {
                    Id = request.Id,
                    BrandId = request.BrandId,
                    ModelId = request.ModelId,
                    ProductionYear = request.ProductionYear,
                    Mileage = request.Mileage,
                    Price = request.Price,
                    ColorId = request.ColorId,
                    VehicleTypeId = request.VehicleTypeId,
                    FuelTypeId = request.FuelTypeId,
                    GearboxId = request.GearboxId,
                    PhotoUrl = request.PhotoUrl,
                    ImageLocalPath = request.ImageLocalPath,
                    Image = request.Image,
                });

                if (request.Image != null)
                {
                    if (!string.IsNullOrEmpty(vehicle.ImageLocalPath))
                    {
                        var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), vehicle.ImageLocalPath);
                        FileInfo file = new FileInfo(oldFilePathDirectory);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    string fileName = vehicle.Id + Path.GetExtension(request.Image.FileName);
                    string filePath = @"wwwroot\VehicleImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        request.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}{_httpContextAccessor.HttpContext.Request.PathBase.Value}";
                    vehicle.PhotoUrl = baseUrl + "/VehicleImages/" + fileName;
                    vehicle.ImageLocalPath = filePath;
                }


                _vehicleWriteRepository.Update(vehicle);
                await _vehicleWriteRepository.SaveAsync();

                return new UpdateVehicleCommandResponse()
                {
                    Result = _mapper.Map<VehicleDto>(vehicle)
                };
            }
            catch (Exception ex)
            {
                return new UpdateVehicleCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
