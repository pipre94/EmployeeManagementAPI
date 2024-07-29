using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetPeopleByIdQuery : IRequest<PeopleEntity>
    {
        public int Id { get; set; }
        public GetPeopleByIdQuery(int id)
        {
            Id = id;
        } 
    }
}
