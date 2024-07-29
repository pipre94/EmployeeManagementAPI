using Domain.Entities;
using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPeopleQuery : IRequest<List<PeopleEntity>> { }
}
