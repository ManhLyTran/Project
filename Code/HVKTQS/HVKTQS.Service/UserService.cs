using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IUserService
    {
        ApplicationUser Add(ApplicationUser User);

        void Update(ApplicationUser User);

        ApplicationUser Delete(int id);

        IEnumerable<ApplicationUser> GetAll();

        ApplicationUser GetById(int id);

        void Save();
    }

    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {
            this._UserRepository = UserRepository;
            this._unitOfWork = unitOfWork;
        }

        public ApplicationUser Add(ApplicationUser User)
        {
            return _UserRepository.Add(User);
        }

        public ApplicationUser Delete(int id)
        {
            return _UserRepository.Delete(id);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public ApplicationUser GetById(int id)
        {
            return _UserRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ApplicationUser User)
        {
            _UserRepository.Update(User);
        }
    }
}