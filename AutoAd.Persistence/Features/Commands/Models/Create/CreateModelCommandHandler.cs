using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Create
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommandRequest, CreateModelCommandResponse>
    {
        private readonly IModelWriteRepository _modelWriteRepository;
        private readonly IMapper _mapper;

        public CreateModelCommandHandler(IModelWriteRepository modelWriteRepository, IMapper mapper)
        {
            _modelWriteRepository = modelWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateModelCommandResponse> Handle(CreateModelCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Model model = _mapper.Map<Model>(new ModelDto
                {
                    Name = request.Name,
                    BrandId = request.BrandId,
                });
                await _modelWriteRepository.AddAsync(model);
                await _modelWriteRepository.SaveAsync();

                return new CreateModelCommandResponse()
                {
                    Result = _mapper.Map<ModelDto>(model)
                };
            }
            catch (Exception ex)
            {
                return new CreateModelCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
