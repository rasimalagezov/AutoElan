using AutoAd.Persistence.Features.Commands.Models.Create;
using AutoAd.Persistence.Features.Commands.Models.Delete;
using AutoAd.Persistence.Features.Commands.Models.Update;
using AutoAd.Persistence.Features.Queries.Models.GetByBrandId;
using AutoAd.Persistence.Features.Queries.Models.GetModelById;
using AutoAd.Persistence.Features.Queries.Models.GetModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/model")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ModelAPIController : ControllerBase
    {
       
        IMediator _mediator;

        public ModelAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetModelsQueryRequest getModelsQueryRequest)
        {
            GetModelsQueryResponse response = await _mediator.Send(getModelsQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetModelByIdQueryRequest getModelByIdQueryRequest)
        {
            GetModelByIdQueryResponse response = await _mediator.Send(getModelByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("brandId/{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetByBrandIdQueryRequest getByBrandIdQueryRequest)
        {
            GetByBrandIdQueryResponse response = await _mediator.Send(getByBrandIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelCommandRequest createModelCommandRequest)
        {
            CreateModelCommandResponse response = await _mediator.Send(createModelCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateModelCommandRequest updateModelCommandRequest)
        {
            UpdateModelCommandResponse response = await _mediator.Send(updateModelCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteModelCommandRequest deleteModelCommandRequest)
        {
            DeleteModelCommandResponse response = await _mediator.Send(deleteModelCommandRequest);
            return Ok(response);
        }
    }
}
