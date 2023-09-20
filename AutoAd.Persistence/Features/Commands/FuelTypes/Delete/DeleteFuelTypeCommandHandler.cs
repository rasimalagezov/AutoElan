using AutoAd.Application.Repositories.FuelTypeRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.FuelTypes.Delete
{
    public class DeleteFuelTypeCommandHandler : IRequestHandler<DeleteFuelTypeCommandRequest, DeleteFuelTypeCommandResponse>
    {
        private readonly IFuelTypeWriteRepository _fuelTypeWriteRepository;

        public DeleteFuelTypeCommandHandler(IFuelTypeWriteRepository fuelTypeWriteRepository)
        {
            _fuelTypeWriteRepository = fuelTypeWriteRepository;
        }

        public async Task<DeleteFuelTypeCommandResponse> Handle(DeleteFuelTypeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _fuelTypeWriteRepository.RemoveAsync(request.Id);
                await _fuelTypeWriteRepository.SaveAsync();

                return new DeleteFuelTypeCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteFuelTypeCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
