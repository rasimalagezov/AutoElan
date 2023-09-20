using AutoAd.Persistence.Features.Commands.FuelTypes.Create;
using AutoAd.Persistence.Features.Commands.FuelTypes.Delete;
using AutoAd.Persistence.Features.Commands.FuelTypes.Update;
using AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypeById;
using AutoAd.Persistence.Features.Queries.FuelTypes.GetFuelTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/fuelType")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class FuelTypeAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FuelTypeAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetFuelTypesQueryRequest getFuelTypesQueryRequest)
        {
            GetFuelTypesQueryResponse response = await _mediator.Send(getFuelTypesQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetFuelTypeByIdQueryRequest getFuelTypeByIdQueryRequest)
        {
            GetFuelTypeByIdQueryResponse response = await _mediator.Send(getFuelTypeByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFuelTypeCommandRequest createFuelTypeCommandRequest)
        {
            CreateFuelTypeCommandResponse response = await _mediator.Send(createFuelTypeCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateFuelTypeCommandRequest updateFuelTypeCommandRequest)
        {
            UpdateFuelTypeCommandResponse response = await _mediator.Send(updateFuelTypeCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFuelTypeCommandRequest deleteFuelTypeCommandRequest)
        {
            DeleteFuelTypeCommandResponse response = await _mediator.Send(deleteFuelTypeCommandRequest);
            return Ok(response);
        }
    }
}
