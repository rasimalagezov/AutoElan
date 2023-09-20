using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository, IMapper mapper)
        {
            _brandWriteRepository = brandWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Brand brand = _mapper.Map<Brand>(new BrandDto
                {
                    Name = request.Name
                });
                await _brandWriteRepository.AddAsync(brand);
                await _brandWriteRepository.SaveAsync();

                return new CreateBrandCommandResponse()
                {
                    Result = _mapper.Map<BrandDto>(brand)
                };
            }
            catch (Exception ex)
            {
                return new CreateBrandCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
