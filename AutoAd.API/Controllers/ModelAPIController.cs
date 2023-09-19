using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoAd.API.Controllers
{
    [Route("api/model")]
    [ApiController]
    public class ModelAPIController : ControllerBase
    {
        private readonly IModelReadRepository _modelReadRepository;
        private readonly IModelWriteRepository _modelWriteRepository;
        private readonly IMapper _mapper;
        private ResponseDto _response;

        public ModelAPIController(IModelReadRepository modelReadRepository, IModelWriteRepository modelWriteRepository, IMapper mapper)
        {
            _modelReadRepository = modelReadRepository;
            _modelWriteRepository = modelWriteRepository;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Model> objList = _modelReadRepository.GetAll().Include(m => m.Brand);

                _response.Result = _mapper.Map<IEnumerable<ModelDto>>(objList);
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
                Model obj = await _modelReadRepository.GetWhere(i => i.Id == id).Include(m => m.Brand).FirstOrDefaultAsync();
                _response.Result = _mapper.Map<ModelDto>(obj);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("brandId/{id:int}")]
        public ResponseDto GetByBrandId(int id)
        {
            try
            {
                IEnumerable<Model> objList = _modelReadRepository.GetWhere(m => m.BrandId == id).Include(m => m.Brand);

                _response.Result = _mapper.Map<IEnumerable<ModelDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public async Task<ResponseDto> Create([FromBody] ModelDto modelDto)
        {
            try
            {
                Model model = _mapper.Map<Model>(modelDto);
                await _modelWriteRepository.AddAsync(model);
                await _modelWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<ModelDto>(model);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDto> Edit([FromBody] ModelDto modelDto)
        {
            try
            {
                Model model = _mapper.Map<Model>(modelDto);
                _modelWriteRepository.Update(model);
                await _modelWriteRepository.SaveAsync();

                _response.Result = _mapper.Map<ModelDto>(model);
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
                await _modelWriteRepository.RemoveAsync(id);
                await _modelWriteRepository.SaveAsync();
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
