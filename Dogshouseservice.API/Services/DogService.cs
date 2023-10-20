using Dogshouseservice.API.Commads.CreateDogCommand;
using Dogshouseservice.API.DTOs;
using Dogshouseservice.API.Models;
using Dogshouseservice.API.Queries.GetDogsQuery;
using Dogshouseservice.API.Repositories.Interfaces;
using Dogshouseservice.API.Services.Interfaces;
using Mapster;

namespace Dogshouseservice.API.Services
{
    public class DogService: IDogService
    {
        private readonly IDogRepository _repository;

        public DogService(IDogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> AddDogAsync(CreateDogCommand input)
        {
            Dog dog = new(input.Name, input.Color, input.TailLength, input.Weight);

            return await _repository.AddAsync(dog);
        }

        public async Task<IEnumerable<DogDTO>> GetDogs(GetDogsQuery input)
        {
            int skip = (input.PageNumber - 1) * input.PageSize;

            IEnumerable<Dog> dogs = await _repository.GetList(skip, input.PageSize, input.Sort);

            return dogs.Adapt<IEnumerable<DogDTO>>();
        }
    }
}
