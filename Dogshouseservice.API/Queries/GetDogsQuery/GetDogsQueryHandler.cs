using Dogshouseservice.API.DTOs;
using Dogshouseservice.API.Services.Interfaces;
using MediatR;

namespace Dogshouseservice.API.Queries.GetDogsQuery
{
    public class GetDogsQueryHandler : IRequestHandler<GetDogsQuery, IEnumerable<DogDTO>>
    {
        private readonly IDogService _service;

        public GetDogsQueryHandler(IDogService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<DogDTO>> Handle(GetDogsQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            return await _service.GetDogs(request);
        }
    }
}
