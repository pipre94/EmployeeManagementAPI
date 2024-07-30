using Domain.Entities;

namespace Domain.Interfaces.Respository
{
    public interface IPositionRepository
    {
        Task<List<PositionsEntity>> GetAllPositionsAsync();
    }
}
