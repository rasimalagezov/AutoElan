using AutoAd.Persistence.Features.Commands.Colors.Create;
using AutoAd.Persistence.Features.Commands.Colors.Delete;
using AutoAd.Persistence.Features.Commands.Colors.Update;
using AutoAd.Persistence.Features.Queries.Colors.GetColorById;
using AutoAd.Persistence.Features.Queries.Colors.GetColors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/color")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class ColorAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ColorAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetColorsQueryRequest getColorsQueryRequest)
        {
            GetColorsQueryResponse response = await _mediator.Send(getColorsQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetColorByIdQueryRequest getColorByIdQueryRequest)
        {
            GetColorByIdQueryResponse response = await _mediator.Send(getColorByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateColorCommandRequest createColorCommandRequest)
        {
            CreateColorCommandResponse response = await _mediator.Send(createColorCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateColorCommandRequest updateColorCommandRequest)
        {
            UpdateColorCommandResponse response = await _mediator.Send(updateColorCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteColorCommandRequest deleteColorCommandRequest)
        {
            DeleteColorCommandResponse response = await _mediator.Send(deleteColorCommandRequest);
            return Ok(response);
        }
    }
}
