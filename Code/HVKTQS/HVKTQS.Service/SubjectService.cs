using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface ISubjectService
    {
        Subject Add(Subject Subject);

        void Update(Subject Subject);

        Subject Delete(int id);

        IEnumerable<Subject> GetAll();

        Subject GetById(int id);

        void Save();
    }

    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _SubjectRepository;
        private IUnitOfWork _unitOfWork;

        public SubjectService(ISubjectRepository SubjectRepository, IUnitOfWork unitOfWork)
        {
            this._SubjectRepository = SubjectRepository;
            this._unitOfWork = unitOfWork;
        }

        public Subject Add(Subject Subject)
        {
            return _SubjectRepository.Add(Subject);
        }

        public Subject Delete(int id)
        {
            return _SubjectRepository.Delete(id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _SubjectRepository.GetAll();
        }

        public Subject GetById(int id)
        {
            return _SubjectRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Subject Subject)
        {
            _SubjectRepository.Update(Subject);
        }
    }
}