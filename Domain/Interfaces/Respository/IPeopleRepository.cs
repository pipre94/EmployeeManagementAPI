using Domain.Entities;
using Domain.Models;

namespace Domain.Interfaces.Respository
{
    public interface IPeopleRepository
    {

        Task AddPeople(PeopleModel peopleModel);
        Task<List<PeopleEntity>> GetAllPeople();
        Task<PeopleEntity> GetPeopleById(int id);
        Task<PeopleEntity> UpdatePeopleById(PeopleModel peopleModel);
        Task<bool> DeletePeopleById(int id);

    }
}
