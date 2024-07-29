using Domain.Entities;
using Domain.Interfaces.Respository;
using Domain.Models;
using MediatR;

namespace Application.Queries
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<PeopleEntity>>
    {
        private readonly IPeopleRepository _peopleRepository;
        public GetPeopleQueryHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<List<PeopleEntity>> Handle(GetPeopleQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<PeopleEntity> peopleModels = await _peopleRepository.GetAllPeople();

                return peopleModels;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
