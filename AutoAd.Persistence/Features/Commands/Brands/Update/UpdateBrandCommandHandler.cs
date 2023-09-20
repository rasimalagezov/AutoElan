using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IMapper mapper)
        {
            _brandWriteRepository = brandWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Brand brand = _mapper.Map<Brand>(new BrandDto
                {
                    Id = request.Id,
                    Name = request.Name
                });
                _brandWriteRepository.Update(brand);
                await _brandWriteRepository.SaveAsync();

                return new UpdateBrandCommandResponse()
                {
                    Result = _mapper.Map<BrandDto>(brand)
                };
            }
            catch (Exception ex)
            {
                return new UpdateBrandCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
