using MediatR;

namespace AutoAd.Persistence.Features.Commands.Models.Update
{
    public class UpdateModelCommandRequest : IRequest<UpdateModelCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
