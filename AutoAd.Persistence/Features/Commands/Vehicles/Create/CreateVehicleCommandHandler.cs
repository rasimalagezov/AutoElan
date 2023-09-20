using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AutoAd.Persistence.Features.Commands.Vehicles.Create
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommandRequest, CreateVehicleCommandResponse>
    {
        private readonly IVehicleWriteRepository _vehicleWriteRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleWriteRepository vehicleWriteRepository,IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _vehicleWriteRepository = vehicleWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(new VehicleDto
                {
                    BrandId = request.BrandId,
                    ModelId = request.ModelId,
                    ProductionYear = request.ProductionYear,
                    Mileage = request.Mileage,
                    Price = request.Price,
                    ColorId = request.ColorId,
                    VehicleTypeId = request.VehicleTypeId,
                    FuelTypeId = request.FuelTypeId,
                    GearboxId = request.GearboxId,
                    Image = request.Image,
                });

                await _vehicleWriteRepository.AddAsync(vehicle);
                await _vehicleWriteRepository.SaveAsync();

                if (request.Image != null)
                {

                    string fileName = vehicle.Id + Path.GetExtension(request.Image.FileName);
                    string filePath = @"wwwroot\VehicleImages\" + fileName;

                    var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    FileInfo file = new FileInfo(directoryLocation);
                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        request.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}{_httpContextAccessor.HttpContext.Request.PathBase.Value}";
                    vehicle.PhotoUrl = baseUrl + "/VehicleImages/" + fileName;
                    vehicle.ImageLocalPath = filePath;
                }
                else
                {
                    vehicle.PhotoUrl = "https://placehold.co/600x400";
                }
                _vehicleWriteRepository.Update(vehicle);
                await _vehicleWriteRepository.SaveAsync();

                return new CreateVehicleCommandResponse()
                {
                    Result = _mapper.Map<VehicleDto>(vehicle)
                };
            }
            catch (Exception ex)
            {
                return new CreateVehicleCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
