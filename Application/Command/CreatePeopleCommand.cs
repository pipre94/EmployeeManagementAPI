using Domain.Models;
using MediatR;

namespace Application.Command
{
    public class CreatePeopleCommand : IRequest
    {
        public PeopleModel people { get; set; }
        public CreatePeopleCommand(PeopleModel peopleModel )
        {
            people = peopleModel;
        }
    }
}
