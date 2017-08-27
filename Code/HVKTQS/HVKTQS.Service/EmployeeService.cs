using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IEmployeeService
    {
        Employee Add(Employee Employee);

        void Update(Employee Employee);

        Employee Delete(int id);

        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        void Save();
    }

    internal class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _EmployeeRepository;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork)
        {
            this._EmployeeRepository = EmployeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Employee Add(Employee Employee)
        {
            return _EmployeeRepository.Add(Employee);
        }

        public Employee Delete(int id)
        {
            return _EmployeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _EmployeeRepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _EmployeeRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Employee Employee)
        {
            _EmployeeRepository.Update(Employee);
        }
    }
}