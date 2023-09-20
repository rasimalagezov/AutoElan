using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Create
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public string Name { get; set; }
    }
}
