using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PositionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PositionsEntity>> GetPositionsEntities()
        {
            List<PositionsEntity> listPositions = await _mediator.Send(new GetAllPositionsQuery());
            return listPositions;
        }

    }
}
