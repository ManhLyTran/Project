using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IEventFileService
    {
        EventFile Add(EventFile EventFile);

        void Update(EventFile EventFile);

        EventFile Delete(int id);

        IEnumerable<EventFile> GetAll();

        EventFile GetById(int id);

        void Save();
    }

    internal class EventFileService : IEventFileService
    {
        private IEventFileRepository _EventFileRepository;
        private IUnitOfWork _unitOfWork;

        public EventFileService(IEventFileRepository EventFileRepository, IUnitOfWork unitOfWork)
        {
            this._EventFileRepository = EventFileRepository;
            this._unitOfWork = unitOfWork;
        }

        public EventFile Add(EventFile EventFile)
        {
            return _EventFileRepository.Add(EventFile);
        }

        public EventFile Delete(int id)
        {
            return _EventFileRepository.Delete(id);
        }

        public IEnumerable<EventFile> GetAll()
        {
            return _EventFileRepository.GetAll();
        }

        public EventFile GetById(int id)
        {
            return _EventFileRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(EventFile EventFile)
        {
            _EventFileRepository.Update(EventFile);
        }
    }
}