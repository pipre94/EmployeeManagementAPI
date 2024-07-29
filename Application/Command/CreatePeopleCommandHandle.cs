using Domain.Interfaces.Respository;
using MediatR;

namespace Application.Command
{
    public class CreatePeopleCommandHandle : IRequestHandler<CreatePeopleCommand>
    {
        private readonly IPeopleRepository _peopleRepository;

        public CreatePeopleCommandHandle(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }


        public async Task Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if( request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }
                await _peopleRepository.AddPeople(request.people);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

    }
}
