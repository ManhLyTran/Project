using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IEventService
    {
        Event Add(Event Event);

        void Update(Event Event);

        Event Delete(int id);

        IEnumerable<Event> GetAll();

        Event GetById(int id);

        void Save();
    }

    internal class EventService : IEventService
    {
        private IEventRepository _EventRepository;
        private IUnitOfWork _unitOfWork;

        public EventService(IEventRepository EventRepository, IUnitOfWork unitOfWork)
        {
            this._EventRepository = EventRepository;
            this._unitOfWork = unitOfWork;
        }

        public Event Add(Event Event)
        {
            return _EventRepository.Add(Event);
        }

        public Event Delete(int id)
        {
            return _EventRepository.Delete(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _EventRepository.GetAll();
        }

        public Event GetById(int id)
        {
            return _EventRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Event Event)
        {
            _EventRepository.Update(Event);
        }
    }
}