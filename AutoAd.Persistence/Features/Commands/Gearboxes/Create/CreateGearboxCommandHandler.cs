using AutoAd.Application.DTO;
using AutoAd.Application.Repositories.GearboxRepository;
using AutoAd.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AutoAd.Persistence.Features.Commands.Gearboxes.Create
{
    public class CreateGearboxCommandHandler : IRequestHandler<CreateGearboxCommandRequest, CreateGearboxCommandResponse>
    {
        private readonly IGearboxWriteRepository _gearboxWriteRepository;
        private readonly IMapper _mapper;

        public CreateGearboxCommandHandler(IGearboxWriteRepository gearboxWriteRepository, IMapper mapper)
        {
            _gearboxWriteRepository = gearboxWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateGearboxCommandResponse> Handle(CreateGearboxCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Gearbox gearbox = _mapper.Map<Gearbox>(new GearboxDto
                {
                    Name = request.Name
                });
                await _gearboxWriteRepository.AddAsync(gearbox);
                await _gearboxWriteRepository.SaveAsync();

                return new CreateGearboxCommandResponse()
                {
                    Result = _mapper.Map<GearboxDto>(gearbox)
                };
            }
            catch (Exception ex)
            {
                return new CreateGearboxCommandResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
