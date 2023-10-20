using Dogshouseservice.API.DTOs;
using Dogshouseservice.API.Services.Interfaces;
using MediatR;

namespace Dogshouseservice.API.Commads.CreateDogCommand
{
    public class CreateDogCommandHandler: IRequestHandler<CreateDogCommand, Guid?>
    {
        private readonly IDogService _service;

        public CreateDogCommandHandler(IDogService service)
        {
            _service = service;
        }

        public async Task<Guid?> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await _service.AddDogAsync(request);
        }
    }
}
