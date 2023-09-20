using AutoAd.Persistence.Features.Commands.VehicleTypes.Create;
using AutoAd.Persistence.Features.Commands.VehicleTypes.Delete;
using AutoAd.Persistence.Features.Commands.VehicleTypes.Update;
using AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypeById;
using AutoAd.Persistence.Features.Queries.VehicleTypes.GetVehicleTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/vehicleType")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class VehicleTypeAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleTypeAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetVehicleTypesQueryRequest getVehicleTypesQueryRequest)
        {
            GetVehicleTypesQueryResponse response = await _mediator.Send(getVehicleTypesQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetVehicleTypeByIdQueryRequest getVehicleTypeByIdQueryRequest)
        {
            GetVehicleTypeByIdQueryResponse response = await _mediator.Send(getVehicleTypeByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleTypeCommandRequest createVehicleTypeCommandRequest)
        {
            CreateVehicleTypeCommandResponse response = await _mediator.Send(createVehicleTypeCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateVehicleTypeCommandRequest updateVehicleTypeCommandRequest)
        {
            UpdateVehicleTypeCommandResponse response = await _mediator.Send(updateVehicleTypeCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVehicleTypeCommandRequest deleteVehicleTypeCommandRequest)
        {
            DeleteVehicleTypeCommandResponse response = await _mediator.Send(deleteVehicleTypeCommandRequest);
            return Ok(response);
        }
    }
}
