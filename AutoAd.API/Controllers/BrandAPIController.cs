using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandAPIController : ControllerBase
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public BrandAPIController(IBrandReadRepository brandReadRepository, IBrandWriteRepository brandWriteRepository, IMapper mapper)
        {
            _brandReadRepository = brandReadRepository;
            _brandWriteRepository = brandWriteRepository;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Brand> objList =  _brandReadRepository.GetAll();

                _response.Result = _mapper.Map<IEnumerable<BrandDto>>(objList);
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
                Brand obj = await _brandReadRepository.GetByIdAsync(id);
                _response.Result = _mapper.Map<BrandDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] BrandDto brandDto)
        {
            try
            {
                Brand brand = _mapper.Map<Brand>(brandDto);
                await _brandWriteRepository.AddAsync(brand);
                await _brandWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<BrandDto>(brand);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] BrandDto brandDto)
        {
            try
            {
                Brand brand = _mapper.Map<Brand>(brandDto);
                _brandWriteRepository.Update(brand);
                await _brandWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<BrandDto>(brand);
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
                await _brandWriteRepository.RemoveAsync(id);
                await _brandWriteRepository.SaveAsync();
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
