using AutoAd.Application.Repositories.ColorRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Colors.Delete
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommandRequest, DeleteColorCommandResponse>
    {
        private readonly IColorWriteRepository _colorWriteRepository;

        public DeleteColorCommandHandler(IColorWriteRepository colorWriteRepository)
        {
            _colorWriteRepository = colorWriteRepository;
        }

        public async Task<DeleteColorCommandResponse> Handle(DeleteColorCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _colorWriteRepository.RemoveAsync(request.Id);
                await _colorWriteRepository.SaveAsync();

                return new DeleteColorCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteColorCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
