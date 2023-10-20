using Dogshouseservice.API.Commads.CreateDogCommand;
using Dogshouseservice.API.DTOs;
using Dogshouseservice.API.Queries.GetDogsQuery;

namespace Dogshouseservice.API.Services.Interfaces
{
    public interface IDogService
    {
        public Task<Guid?> AddDogAsync(CreateDogCommand input);
        public Task<IEnumerable<DogDTO>> GetDogs(GetDogsQuery input);

    }
}
