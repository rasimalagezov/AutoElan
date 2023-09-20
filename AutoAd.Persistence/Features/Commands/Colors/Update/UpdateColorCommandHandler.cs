using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Colors.Update
{
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommandRequest, UpdateColorCommandResponse>
    {
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorWriteRepository colorWriteRepository, IMapper mapper)
        {
            _colorWriteRepository = colorWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Color color = _mapper.Map<Color>(new ColorDto
                {
                    Id = request.Id,
                    Name = request.Name
                });
                _colorWriteRepository.Update(color);
                await _colorWriteRepository.SaveAsync();

                return new UpdateColorCommandResponse()
                {
                    Result = _mapper.Map<ColorDto>(color)
                };
            }
            catch (Exception ex)
            {
                return new UpdateColorCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
