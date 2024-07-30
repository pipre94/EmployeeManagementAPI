using Domain.Entities;
using Domain.Interfaces.Respository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, List<PositionsEntity>>
    {
        private readonly IPositionRepository _positionRepository;

        public GetAllPositionsQueryHandler(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<List<PositionsEntity>> Handle(GetAllPositionsQuery getAllPositionsQuery, CancellationToken cancellationToken)
        {
            return await _positionRepository.GetAllPositionsAsync();
        }
    }
}
