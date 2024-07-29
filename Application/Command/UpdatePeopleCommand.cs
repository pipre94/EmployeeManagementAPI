using Domain.Models;
using MediatR;

namespace Application.Command
{
    public class UpdatePeopleCommand : IRequest<PeopleModel>
    {
        public int Id { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int PositionId { get; set; }

        public UpdatePeopleCommand(int id)
        {
            Id = id;
        }
    }
}
