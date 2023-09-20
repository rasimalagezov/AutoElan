using MediatR;

namespace AutoAd.Persistence.Features.Commands.Brands.Update
{
    public class UpdateBrandCommandRequest : IRequest<UpdateBrandCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
