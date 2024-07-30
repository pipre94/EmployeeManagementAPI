using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllPositionsQuery : IRequest<List<PositionsEntity>> { }
}
