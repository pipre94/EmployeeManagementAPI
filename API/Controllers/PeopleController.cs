using Application.Command;
using Application.Queries;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IMediator _mediator;

        public PeopleController(ILogger<PeopleController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PeopleModel peopleModel)
        {
            await _mediator.Send(new CreatePeopleCommand(peopleModel));
            return Ok();
        }

        [HttpGet]
        public async Task<List<PeopleEntity>> GetPeople()
        {
            List<PeopleEntity> listPeople = await _mediator.Send(new GetPeopleQuery());
            return listPeople;
        }

        [HttpGet("{id}")]
        public async Task<PeopleEntity> GetPeopleById(int id)
        {
            PeopleEntity peopleModel = await _mediator.Send(new GetPeopleByIdQuery(id));
            return peopleModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeopleById(int id,[FromBody] UpdatePeopleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("The ID in the URL does not match the ID in the command.");
            }
            var result = await _mediator.Send(command);
            if (result != null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeoplById(int id)
        {
            var result  = await _mediator.Send(new DeletePeopleCommand(id));
            if (!result)
            {
                return BadRequest("The user could not be removed from the database.");
            }
            return Ok();
        }

    }
}
