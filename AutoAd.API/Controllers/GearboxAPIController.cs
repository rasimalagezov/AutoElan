using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/gearbox")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class GearboxAPIController : ControllerBase
    {
        private readonly IGearboxReadRepository _gearboxReadRepository;
        private readonly IGearboxWriteRepository _gearboxWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public GearboxAPIController(IGearboxReadRepository gearboxReadRepository, IGearboxWriteRepository gearboxWriteRepository, IMapper mapper)
        {
            _gearboxReadRepository = gearboxReadRepository;
            _gearboxWriteRepository = gearboxWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Gearbox> objList = _gearboxReadRepository.GetAll();

                _response.Result = _mapper.Map<IEnumerable<GearboxDto>>(objList);
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
        public async Task <ResponseDto> Get(int id)
        {
            try
            {
                Gearbox obj = await _gearboxReadRepository.GetByIdAsync(id);
                _response.Result = _mapper.Map<GearboxDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] GearboxDto gearboxDto)
        {
            try
            {
                Gearbox gearbox = _mapper.Map<Gearbox>(gearboxDto);
                await _gearboxWriteRepository.AddAsync(gearbox);
                await _gearboxWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<GearboxDto>(gearbox);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] GearboxDto gearboxDto)
        {
            try
            {
                Gearbox gearbox = _mapper.Map<Gearbox>(gearboxDto);
                _gearboxWriteRepository.Update(gearbox);
                await _gearboxWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<GearboxDto>(gearbox);
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
                await _gearboxWriteRepository.RemoveAsync(id);
                await _gearboxWriteRepository.SaveAsync();
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
