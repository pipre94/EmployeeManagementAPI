using Domain.Entities;
using Domain.Interfaces.Respository;
using MediatR;

namespace Application.Queries
{
    public class GetPeopleByIdQueryHandler : IRequestHandler<GetPeopleByIdQuery, PeopleEntity>
    {
        private readonly IPeopleRepository _peopleRepository;

        public GetPeopleByIdQueryHandler(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<PeopleEntity> Handle(GetPeopleByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
               PeopleEntity  peopleEntity = await _peopleRepository.GetPeopleById(query.Id);
                return peopleEntity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
