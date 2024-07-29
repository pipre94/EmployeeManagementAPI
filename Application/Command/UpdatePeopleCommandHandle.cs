using Domain.Interfaces.Respository;
using Domain.Models;
using MediatR;

namespace Application.Command
{
    public class UpdatePeopleCommandHandle : IRequestHandler<UpdatePeopleCommand, PeopleModel>
    {
        private readonly IPeopleRepository _peopleRepository;

        public UpdatePeopleCommandHandle(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<PeopleModel> Handle(UpdatePeopleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request == null)
                {
                    throw new NullReferenceException();
                }
                PeopleModel peopleModel = new();
                peopleModel.Id = request.Id;
                peopleModel.IdNumber = request.IdNumber;
                peopleModel.Name = request.Name;
                peopleModel.AdmissionDate = request.AdmissionDate;
                peopleModel.Photo = request.Photo;
                peopleModel.PositionId = request.PositionId;
                await _peopleRepository.UpdatePeopleById(peopleModel);
                return peopleModel;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
