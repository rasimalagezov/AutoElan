using AutoAd.Application.Repositories.GearboxRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Delete
{
    public class DeleteGearboxCommandHandler : IRequestHandler<DeleteGearboxCommandRequest, DeleteGearboxCommandResponse>
    {
        private readonly IGearboxWriteRepository _gearboxWriteRepository;

        public DeleteGearboxCommandHandler(IGearboxWriteRepository gearboxWriteRepository)
        {
            _gearboxWriteRepository = gearboxWriteRepository;
        }

        public async Task<DeleteGearboxCommandResponse> Handle(DeleteGearboxCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _gearboxWriteRepository.RemoveAsync(request.Id);
                await _gearboxWriteRepository.SaveAsync();

                return new DeleteGearboxCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteGearboxCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
