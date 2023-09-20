using AutoAd.Persistence.Features.Commands.Brands.Create;
using AutoAd.Persistence.Features.Commands.Brands.Delete;
using AutoAd.Persistence.Features.Commands.Brands.Update;
using AutoAd.Persistence.Features.Queries.Brands.GetBrandById;
using AutoAd.Persistence.Features.Queries.Brands.GetBrands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoAd.API.Controllers
{
    [Route("api/brand")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class BrandAPIController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetBrandsQueryRequest getBrandsQueryRequest)
        {
            GetBrandsQueryResponse response = await _mediator.Send(getBrandsQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> Get([FromRoute] GetBrandByIdQueryRequest getBrandByIdQueryRequest)
        {
            GetBrandByIdQueryResponse response = await _mediator.Send(getBrandByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommandRequest createBrandCommandRequest)
        {
            CreateBrandCommandResponse response = await _mediator.Send(createBrandCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            UpdateBrandCommandResponse response = await _mediator.Send(updateBrandCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommandRequest deleteBrandCommandRequest)
        {
            DeleteBrandCommandResponse response = await _mediator.Send(deleteBrandCommandRequest);
            return Ok(response);
        }
    }
}
