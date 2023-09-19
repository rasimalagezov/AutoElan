using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.BrandRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAd.Application.Features.Commands.Brands.Create
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
                 await _brandWriteRepository.AddAsync(new Brand()
                {
                    Name = request.brandDto.Name,
                });
                await _brandWriteRepository.SaveAsync();

                return new CreateBrandCommandResponse();
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
