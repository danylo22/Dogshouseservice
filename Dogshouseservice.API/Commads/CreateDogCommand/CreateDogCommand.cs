using Dogshouseservice.API.DTOs;
using MediatR;

namespace Dogshouseservice.API.Commads.CreateDogCommand
{
    public class CreateDogCommand : IRequest<Guid?>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }
    }
}
