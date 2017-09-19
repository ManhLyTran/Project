using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IDepartmentService
    {
        Department Add(Department Department);

        void Update(Department Department);

        Department Delete(int id);

        IEnumerable<Department> GetAll();

        Department GetById(int id);

        void Save();
    }

    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _DepartmentRepository;
        private IUnitOfWork _unitOfWork;

        public DepartmentService(IDepartmentRepository DepartmentRepository, IUnitOfWork unitOfWork)
        {
            this._DepartmentRepository = DepartmentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Department Add(Department Department)
        {
            return _DepartmentRepository.Add(Department);
        }

        public Department Delete(int id)
        {
            return _DepartmentRepository.Delete(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }

        public Department GetById(int id)
        {
            return _DepartmentRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Department Department)
        {
            _DepartmentRepository.Update(Department);
        }
    }
}