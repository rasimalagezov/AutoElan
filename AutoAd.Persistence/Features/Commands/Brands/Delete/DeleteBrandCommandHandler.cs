using AutoAd.Application.Repositories.BrandRepository;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Delete
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommandRequest, DeleteBrandCommandResponse>
    {
        private readonly IBrandWriteRepository _brandWriteRepository;

        public DeleteBrandCommandHandler(IBrandWriteRepository brandWriteRepository)
        {
            _brandWriteRepository = brandWriteRepository;
        }

        public async Task<DeleteBrandCommandResponse> Handle(DeleteBrandCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _brandWriteRepository.RemoveAsync(request.Id);
                await _brandWriteRepository.SaveAsync();

                return new DeleteBrandCommandResponse();
            }
            catch (Exception ex)
            {
                return new DeleteBrandCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
