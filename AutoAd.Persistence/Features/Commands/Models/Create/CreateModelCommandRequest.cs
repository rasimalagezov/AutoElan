using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Create
{
    public class CreateModelCommandRequest : IRequest<CreateModelCommandResponse>
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
