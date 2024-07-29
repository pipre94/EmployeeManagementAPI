using MediatR;

namespace Application.Command
{
    public class DeletePeopleCommand : IRequest<bool>
    {
        public int Id { get; set; } 
        public DeletePeopleCommand(int id) 
        {
            Id = id;

        }
    }
}
