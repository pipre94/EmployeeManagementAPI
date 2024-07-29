using Domain.Interfaces.Respository;
using MediatR;

namespace Application.Command
{
    public class DeletePeopleCommandHandle : IRequestHandler<DeletePeopleCommand, bool>
    {
        private readonly IPeopleRepository _peopleRepository;

        public DeletePeopleCommandHandle(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<bool> Handle(DeletePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
               return await _peopleRepository.DeletePeopleById(request.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
