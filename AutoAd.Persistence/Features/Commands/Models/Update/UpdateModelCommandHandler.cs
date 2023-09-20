using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ModelRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Update
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommandRequest, UpdateModelCommandResponse>
    {
        private readonly IModelWriteRepository _modelWriteRepository;
        private readonly IMapper _mapper;

        public UpdateModelCommandHandler(IModelWriteRepository modelWriteRepository, IMapper mapper)
        {
            _modelWriteRepository = modelWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateModelCommandResponse> Handle(UpdateModelCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Model model = _mapper.Map<Model>(new ModelDto
                {
                    Id = request.Id,
                    Name = request.Name,
                    BrandId = request.BrandId,
                });
                _modelWriteRepository.Update(model);
                await _modelWriteRepository.SaveAsync();

                return new UpdateModelCommandResponse()
                {
                    Result = _mapper.Map<ModelDto>(model)
                };
            }
            catch (Exception ex)
            {
                return new UpdateModelCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
