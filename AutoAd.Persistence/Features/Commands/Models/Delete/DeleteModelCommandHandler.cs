using AutoAd.Application.Repositories.ModelRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Delete
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommandRequest, DeleteModelCommandResponse>
    {
        private readonly IModelWriteRepository _modelWriteRepository;

        public DeleteModelCommandHandler(IModelWriteRepository modelWriteRepository)
        {
            _modelWriteRepository = modelWriteRepository;
        }

        public async Task<DeleteModelCommandResponse> Handle(DeleteModelCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _modelWriteRepository.RemoveAsync(request.Id);
                await _modelWriteRepository.SaveAsync();

                return new DeleteModelCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteModelCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
