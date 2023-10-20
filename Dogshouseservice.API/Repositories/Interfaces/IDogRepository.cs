using Dogshouseservice.API.Models;

namespace Dogshouseservice.API.Repositories.Interfaces
{
    public interface IDogRepository
    {
        public Task<Guid?> AddAsync(Dog dog);
        public Task<IEnumerable<Dog>> GetList(int skip = 0, int pageSize = 10, string sort = "weight");

    }
}
