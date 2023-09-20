using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.ColorRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Colors.Create
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommandRequest, CreateColorCommandResponse>
    {
        private readonly IColorWriteRepository _colorWriteRepository;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorWriteRepository colorWriteRepository, IMapper mapper)
        {
            _colorWriteRepository = colorWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateColorCommandResponse> Handle(CreateColorCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Color color = _mapper.Map<Color>(new ColorDto
                {
                    Name = request.Name
                });
                await _colorWriteRepository.AddAsync(color);
                await _colorWriteRepository.SaveAsync();

                return new CreateColorCommandResponse()
                {
                    Result = _mapper.Map<ColorDto>(color)
                };
            }
            catch (Exception ex)
            {
                return new CreateColorCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
