using AutoAd.Persistence.Features.Commands.Gearboxes.Create;
using AutoAd.Persistence.Features.Commands.Gearboxes.Delete;
using AutoAd.Persistence.Features.Commands.Gearboxes.Update;
using AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxById;
using AutoAd.Persistence.Features.Queries.Gearboxes.GetGearboxes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/gearbox")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class GearboxAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GearboxAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetGearboxesQueryRequest getGearboxesQueryRequest)
        {
            GetGearboxesQueryResponse response = await _mediator.Send(getGearboxesQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetGearboxByIdQueryRequest getGearboxByIdQueryRequest)
        {
            GetGearboxByIdQueryResponse response = await _mediator.Send(getGearboxByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGearboxCommandRequest createGearboxCommandRequest)
        {
            CreateGearboxCommandResponse response = await _mediator.Send(createGearboxCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateGearboxCommandRequest updateGearboxCommandRequest)
        {
            UpdateGearboxCommandResponse response = await _mediator.Send(updateGearboxCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGearboxCommandRequest deleteGearboxCommandRequest)
        {
            DeleteGearboxCommandResponse response = await _mediator.Send(deleteGearboxCommandRequest);
            return Ok(response);
        }
    }
}
