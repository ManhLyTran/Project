using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IEventNoteService
    {
        EventNote Add(EventNote EventNote);

        void Update(EventNote EventNote);

        EventNote Delete(int id);

        IEnumerable<EventNote> GetAll();

        EventNote GetById(int id);

        void Save();
    }

    public class EventNoteService : IEventNoteService
    {
        private IEventNoteRepository _EventNoteRepository;
        private IUnitOfWork _unitOfWork;

        public EventNoteService(IEventNoteRepository EventNoteRepository, IUnitOfWork unitOfWork)
        {
            this._EventNoteRepository = EventNoteRepository;
            this._unitOfWork = unitOfWork;
        }

        public EventNote Add(EventNote EventNote)
        {
            return _EventNoteRepository.Add(EventNote);
        }

        public EventNote Delete(int id)
        {
            return _EventNoteRepository.Delete(id);
        }

        public IEnumerable<EventNote> GetAll()
        {
            return _EventNoteRepository.GetAll();
        }

        public EventNote GetById(int id)
        {
            return _EventNoteRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(EventNote EventNote)
        {
            _EventNoteRepository.Update(EventNote);
        }
    }
}