using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IEventUserService
    {
        EventUser Add(EventUser EventUser);

        void Update(EventUser EventUser);

        EventUser Delete(int id);

        IEnumerable<EventUser> GetAll();

        EventUser GetById(int id);

        void Save();
    }

    public class EventUserService : IEventUserService
    {
        private IEventUserRepository _EventUserRepository;
        private IUnitOfWork _unitOfWork;

        public EventUserService(IEventUserRepository EventUserRepository, IUnitOfWork unitOfWork)
        {
            this._EventUserRepository = EventUserRepository;
            this._unitOfWork = unitOfWork;
        }

        public EventUser Add(EventUser EventUser)
        {
            return _EventUserRepository.Add(EventUser);
        }

        public EventUser Delete(int id)
        {
            return _EventUserRepository.Delete(id);
        }

        public IEnumerable<EventUser> GetAll()
        {
            return _EventUserRepository.GetAll();
        }

        public EventUser GetById(int id)
        {
            return _EventUserRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(EventUser EventUser)
        {
            _EventUserRepository.Update(EventUser);
        }
    }
}