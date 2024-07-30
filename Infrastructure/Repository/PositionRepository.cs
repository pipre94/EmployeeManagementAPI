using Domain.Entities;
using Domain.Interfaces.Respository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DataBaseContext _baseContext;

        public PositionRepository(DataBaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public async Task<List<PositionsEntity>> GetAllPositionsAsync()
        {
            return await _baseContext.Positions.ToListAsync();
        }

    }
}
