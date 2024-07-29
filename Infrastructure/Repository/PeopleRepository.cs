using Domain.Entities;
using Domain.Interfaces.Respository;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DataBaseContext _baseContext;

        public PeopleRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task AddPeople(PeopleModel peopleModel)
        {
            PeopleEntity peopleEntity = new PeopleEntity();
            peopleEntity.IdNumber = peopleModel.IdNumber;
            peopleEntity.Name = peopleModel.Name;
            peopleEntity.Photo = peopleModel.Photo;
            peopleEntity.AdmissionDate = peopleModel.AdmissionDate;
            peopleEntity.PositionId = peopleModel.PositionId;

            await _baseContext.AddAsync(peopleEntity);
            await _baseContext.SaveChangesAsync();
        }

        public async Task<List<PeopleEntity>> GetAllPeople()
        {
            return await _baseContext.People
                .Include(p => p.PositionsEntity)
                .Select (p => 
                new PeopleEntity 
                {
                    Id = p.Id,
                    IdNumber = p.IdNumber,
                    Name = p.Name,
                    Photo = p.Photo,
                    AdmissionDate = p.AdmissionDate,
                    PositionsEntity = new PositionsEntity
                    {
                        IdPosition = p.PositionsEntity.IdPosition,
                        Name = p.PositionsEntity.Name
                    }

                }).ToListAsync();
        }
        public async Task<PeopleEntity> GetPeopleById(int id) 
        {
            return await _baseContext.People
                    .Include(p => p.PositionsEntity)
                    .Where(p => p.Id == id)
                    .Select(p =>
                    new PeopleEntity
                    {
                        Id = p.Id,
                        IdNumber = p.IdNumber,
                        Name = p.Name,
                        Photo = p.Photo,
                        AdmissionDate = p.AdmissionDate,
                        PositionsEntity = new PositionsEntity
                        {
                            IdPosition = p.PositionsEntity.IdPosition,
                            Name = p.PositionsEntity.Name
                        }

                    }).FirstOrDefaultAsync();
        }
        public async Task<PeopleEntity> UpdatePeopleById(PeopleModel peopleModel)
        {
            var peopleEntity = await _baseContext.People.FindAsync(peopleModel.Id);
            if (peopleEntity == null)
            {
                return null; 
            }
            peopleEntity.IdNumber = peopleModel.IdNumber;
            peopleEntity.Name = peopleModel.Name;
            peopleEntity.Photo = peopleModel.Photo;
            peopleEntity.AdmissionDate = peopleModel.AdmissionDate;
            peopleEntity.PositionId = peopleModel.PositionId;
            _baseContext.People.Update(peopleEntity);
            await _baseContext.SaveChangesAsync();

            return peopleEntity;
        }

        public async Task<bool> DeletePeopleById(int id)
        {
            var peopleEntity = await _baseContext.People.FindAsync(id);
            if (peopleEntity == null)
            {
                return false;
            }

            _baseContext.People.Remove(peopleEntity);
            await _baseContext.SaveChangesAsync();
            return true;
        }
    }
}
