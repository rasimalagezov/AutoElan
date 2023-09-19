using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.FuelTypeRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/fuelType")]
    [ApiController]
    public class FuelTypeAPIController : ControllerBase
    {
        private readonly IFuelTypeReadRepository _fuelTypeReadRepository;
        private readonly IFuelTypeWriteRepository _fuelTypeWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public FuelTypeAPIController(IFuelTypeReadRepository fuelTypeReadRepository, IFuelTypeWriteRepository fuelTypeWriteRepository, IMapper mapper)
        {
            _fuelTypeReadRepository = fuelTypeReadRepository;
            _fuelTypeWriteRepository = fuelTypeWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<FuelType> objList = _fuelTypeReadRepository.GetAll();

                _response.Result = _mapper.Map<IEnumerable<FuelTypeDto>>(objList);
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
                FuelType obj = await _fuelTypeReadRepository.GetByIdAsync(id);
                _response.Result = _mapper.Map<FuelTypeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] FuelTypeDto fuelTypeDto)
        {
            try
            {
                FuelType fuelType = _mapper.Map<FuelType>(fuelTypeDto);
                await _fuelTypeWriteRepository.AddAsync(fuelType);
                await _fuelTypeWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<FuelTypeDto>(fuelType);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] FuelTypeDto fuelTypeDto)
        {
            try
            {
                FuelType fuelType = _mapper.Map<FuelType>(fuelTypeDto);
                _fuelTypeWriteRepository.Update(fuelType);
                await _fuelTypeWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<FuelTypeDto>(fuelType);
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
                await _fuelTypeWriteRepository.RemoveAsync(id);
                await _fuelTypeWriteRepository.SaveAsync();
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
