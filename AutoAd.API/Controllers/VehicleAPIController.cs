using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Application.Repositories.VehicleRepository;
using AutoAd.Domain.Entities;
using AutoAd.Persistence.Contexts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.API.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleAPIController : ControllerBase
    {
        private readonly IVehicleReadRepository _vehicleReadRepository;
        private readonly IVehicleWriteRepository _vehicleWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public VehicleAPIController(IVehicleReadRepository vehicleReadRepository, IVehicleWriteRepository vehicleWriteRepository, IMapper mapper)
        {
            _vehicleReadRepository = vehicleReadRepository;
            _vehicleWriteRepository = vehicleWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Vehicle> objList = _vehicleReadRepository.GetAll(false)
                .Include(b => b.Brand)
                .Include(m => m.Model)
                .Include(c => c.Color)
                .Include(vt => vt.VehicleType)
                .Include(ft => ft.FuelType)
                .Include(g => g.Gearbox).ToList();

                _response.Result = _mapper.Map<IEnumerable<VehicleDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("search")]
        public ResponseDto Search(string? brandName, string? modelName, int? minProductionYear, int? maxProductionYear, long? minPrice, long? maxPrice)
        {
            try
            {
                IQueryable<Vehicle> query = _vehicleReadRepository.GetAll();
                if (!string.IsNullOrEmpty(brandName))
                {
                    query = query.Where(v => v.Brand.Name == brandName);
                }
                if (!string.IsNullOrEmpty(modelName))
                {
                    query = query.Where(v => v.Model.Name == modelName);
                }
                if (minProductionYear>0)
                {
                    query = query.Where(v => v.ProductionYear >= minProductionYear);
                }
                if (maxProductionYear > 0)
                {
                    query = query.Where(v => v.ProductionYear <= maxProductionYear);
                }
                if (minPrice > 0)
                {
                    query = query.Where(v => v.Price >= minPrice);
                }
                if (maxPrice > 0)
                {
                    query = query.Where(v => v.Price <= maxPrice);
                }

                query.Include(b => b.Brand)
                .Include(m => m.Model)
                .Include(c => c.Color)
                .Include(vt => vt.VehicleType)
                .Include(ft => ft.FuelType)
                .Include(g => g.Gearbox).ToList();

                _response.Result = _mapper.Map<IEnumerable<VehicleDto>>(query);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                Vehicle obj = await _vehicleReadRepository.GetWhere(v => v.Id == id)
                .Include(b => b.Brand)
                .Include(m => m.Model)
                .Include(c => c.Color)
                .Include(vt => vt.VehicleType)
                .Include(ft => ft.FuelType)
                .Include(g => g.Gearbox).FirstOrDefaultAsync();

                _response.Result = _mapper.Map<VehicleDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Create(VehicleDto vehicleDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);
                await _vehicleWriteRepository.AddAsync(vehicle);
                await _vehicleWriteRepository.SaveAsync();

                if (vehicleDto.Image != null)
                {

                    string fileName = vehicle.Id + Path.GetExtension(vehicleDto.Image.FileName);
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
                        vehicleDto.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    vehicle.PhotoUrl = baseUrl + "/VehicleImages/" + fileName;
                    vehicle.ImageLocalPath = filePath;
                }
                else
                {
                    vehicle.PhotoUrl = "https://placehold.co/600x400";
                }
                _vehicleWriteRepository.Update(vehicle);
                await _vehicleWriteRepository.SaveAsync();
                _response.Result = _mapper.Map<VehicleDto>(vehicle);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Edit(VehicleDto vehicleDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(vehicleDto);

                if (vehicleDto.Image != null)
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

                    string fileName = vehicle.Id + Path.GetExtension(vehicleDto.Image.FileName);
                    string filePath = @"wwwroot\VehicleImages\" + fileName;
                    var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                    using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                    {
                        vehicleDto.Image.CopyTo(fileStream);
                    }
                    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                    vehicle.PhotoUrl = baseUrl + "/VehicleImages/" + fileName;
                    vehicle.ImageLocalPath = filePath;
                }


                _vehicleWriteRepository.Update(vehicle);
                await _vehicleWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<VehicleDto>(vehicle);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Vehicle obj = await _vehicleReadRepository.GetSingleAsync(v => v.Id == id);
                if (!string.IsNullOrEmpty(obj.ImageLocalPath))
                {
                    var oldFilePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), obj.ImageLocalPath);
                    FileInfo file = new FileInfo(oldFilePathDirectory);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                _vehicleWriteRepository.Remove(obj);
                await _vehicleWriteRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
