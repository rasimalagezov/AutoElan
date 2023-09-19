using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.VehicleTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/vehicleType")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class VehicleTypeAPIController : ControllerBase
    {
        private readonly IVehicleTypeReadRepository _vehicleTypeReadRepository;
        private readonly IVehicleTypeWriteRepository _vehicleTypeWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public VehicleTypeAPIController(IVehicleTypeReadRepository vehicleTypeReadRepository, IVehicleTypeWriteRepository vehicleTypeWriteRepository, IMapper mapper)
        {
            _vehicleTypeReadRepository = vehicleTypeReadRepository;
            _vehicleTypeWriteRepository = vehicleTypeWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<VehicleType> objList = _vehicleTypeReadRepository.GetAll();

                _response.Result = _mapper.Map<IEnumerable<VehicleTypeDto>>(objList);
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
                VehicleType obj = await _vehicleTypeReadRepository.GetByIdAsync(id);
                _response.Result = _mapper.Map<VehicleTypeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] VehicleTypeDto vehicleTypeDto)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(vehicleTypeDto);
                await _vehicleTypeWriteRepository.AddAsync(vehicleType);
                await _vehicleTypeWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<VehicleTypeDto>(vehicleType);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] VehicleTypeDto vehicleTypeDto)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(vehicleTypeDto);
                _vehicleTypeWriteRepository.Update(vehicleType);
                await _vehicleTypeWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<VehicleTypeDto>(vehicleType);
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
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                await _vehicleTypeWriteRepository.RemoveAsync(id);
                await _vehicleTypeWriteRepository.SaveAsync();
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
