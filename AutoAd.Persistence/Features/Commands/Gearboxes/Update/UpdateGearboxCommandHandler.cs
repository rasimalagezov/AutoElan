using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Update
{
    public class UpdateGearboxCommandHandler : IRequestHandler<UpdateGearboxCommandRequest, UpdateGearboxCommandResponse>
    {
        private readonly IGearboxWriteRepository _gearboxWriteRepository;
        private readonly IMapper _mapper;

        public UpdateGearboxCommandHandler(IGearboxWriteRepository gearboxWriteRepository, IMapper mapper)
        {
            _gearboxWriteRepository = gearboxWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGearboxCommandResponse> Handle(UpdateGearboxCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Gearbox gearbox = _mapper.Map<Gearbox>(new GearboxDto
                {
                    Id = request.Id,
                    Name = request.Name
                });
                _gearboxWriteRepository.Update(gearbox);
                await _gearboxWriteRepository.SaveAsync();

                return new UpdateGearboxCommandResponse()
                {
                    Result = _mapper.Map<GearboxDto>(gearbox)
                };
            }
            catch (Exception ex)
            {
                return new UpdateGearboxCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
