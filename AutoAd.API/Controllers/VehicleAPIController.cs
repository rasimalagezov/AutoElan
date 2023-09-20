using AutoAd.Persistence.Features.Queries.Vehicles.GetVehicleById;
using AutoAd.Persistence.Features.Queries.Vehicles.GetVehicles;
using AutoAd.Persistence.Features.Queries.Vehicles.GetVehiclesBySearch;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoAd.Persistence.Features.Commands.Vehicles.Create;
using AutoAd.Persistence.Features.Commands.Vehicles.Update;
using AutoAd.Persistence.Features.Commands.Vehicles.Delete;
using Microsoft.AspNetCore.Authorization;

namespace AutoAd.API.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetVehiclesQueryRequest getVehiclesQueryRequest)
        {
            GetVehiclesQueryResponse response = await _mediator.Send(getVehiclesQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetVehicleByIdQueryRequest getVehicleByIdQueryRequest)
        {
            GetVehicleByIdQueryResponse response = await _mediator.Send(getVehicleByIdQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(GetVehiclesBySearchQueryRequest getVehiclesBySearchQueryRequest)
        {
            GetVehiclesBySearchQueryResponse response = await _mediator.Send(getVehiclesBySearchQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create(CreateVehicleCommandRequest createVehicleCommandRequest)
        {
            CreateVehicleCommandResponse response = await _mediator.Send(createVehicleCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Edit(UpdateVehicleCommandRequest updateVehicleCommandRequest)
        {
            UpdateVehicleCommandResponse response = await _mediator.Send(updateVehicleCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "ADMIN")]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteVehicleCommandRequest deleteVehicleCommandRequest)
        {
            DeleteVehicleCommandResponse response = await _mediator.Send(deleteVehicleCommandRequest);
            return Ok(response);
        }
    }
}
