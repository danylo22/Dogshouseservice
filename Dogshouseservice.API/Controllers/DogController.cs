using Dogshouseservice.API.Commads.CreateDogCommand;
using Dogshouseservice.API.DTOs;
using Dogshouseservice.API.Queries.GetDogsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.API.Controllers
{
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("dog")]
        public async Task<IActionResult> Post([FromBody] CreateDogCommand command)
        {
            if (command.TailLength <= 0)
            {
                return BadRequest("Tail length cannot be negative.");
            }

            if (command.Weight <= 0)
            {
                return BadRequest("Tail length cannot be negative.");
            }

            Guid? id = await _mediator.Send(command);

            if (id == null)
            {
                return BadRequest("Name is duplicate.");
            }

            return Ok(id);
        }

        [HttpGet("dogs")]
        public async Task<IActionResult> Get([FromQuery] GetDogsQuery query)
        {
            if (query.PageNumber < 1)
            {
                return BadRequest("PageNumber should be greater than 0.");
            }

            if (query.PageSize < 1)
            {
                return BadRequest("PageSize should be greater than 0.");
            }

            IEnumerable<DogDTO> dogs = await _mediator.Send(query);

            return Ok(dogs);
        }
    }
}