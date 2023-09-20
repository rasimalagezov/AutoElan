using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Delete
{
    public class DeleteBrandCommandRequest : IRequest<DeleteBrandCommandResponse>
    {
        public int Id { get; set; }
    }
}
