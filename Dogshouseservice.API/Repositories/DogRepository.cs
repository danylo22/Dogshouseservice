using Azure.Core;
using Dogshouseservice.API.Models;
using Dogshouseservice.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.API.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly ApplicationDbContext _context;

        public DogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid?> AddAsync(Dog dog)
        {
            try
            {
                await _context.Dogs.AddAsync(dog);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return null;
            }

            return dog.Id;
        }

        public async Task<IEnumerable<Dog>> GetList(int skip = 0, int pageSize = 10, string orderBy = "weight")
        {
            IQueryable<Dog> query = _context.Dogs;

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "weight_desc":
                        query = query.OrderByDescending(a => a.Weight);
                        break;
                    case "weight":
                        query = query.OrderBy(a => a.Weight);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(a => a.Weight);
                        break;
                    case "name":
                        query = query.OrderBy(a => a.Weight);
                        break;
                }
            }

            return await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
