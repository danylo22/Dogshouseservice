using Dogshouseservice.API.DTOs;
using MediatR;

namespace Dogshouseservice.API.Queries.GetDogsQuery
{
    public class GetDogsQuery : IRequest<IEnumerable<DogDTO>>
    {
        public string Sort { get; set; } = string.Empty;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
