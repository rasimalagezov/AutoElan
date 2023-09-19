using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/color")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class ColorAPIController : ControllerBase
    {
        private readonly IColorReadRepository _colorReadRepository;
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public ColorAPIController(IColorReadRepository colorReadRepository, IColorWriteRepository colorWriteRepository, IMapper mapper)
        {
            _colorReadRepository = colorReadRepository;
            _colorWriteRepository = colorWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Color> objList = _colorReadRepository.GetAll();

                _response.Result = _mapper.Map<IEnumerable<ColorDto>>(objList);
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
                Color obj = await _colorReadRepository.GetByIdAsync(id);
                _response.Result = _mapper.Map<ColorDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] ColorDto colorDto)
        {
            try
            {
                Color color = _mapper.Map<Color>(colorDto);
                await _colorWriteRepository.AddAsync(color);
                await _colorWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<ColorDto>(color);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] ColorDto colorDto)
        {
            try
            {
                Color color = _mapper.Map<Color>(colorDto);
                _colorWriteRepository.Update(color);
                await _colorWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<ColorDto>(color);
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
                await _colorWriteRepository.RemoveAsync(id);
                await _colorWriteRepository.SaveAsync();
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
