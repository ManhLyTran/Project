using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IUserService
    {
        User Add(User User);

        void Update(User User);

        User Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

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

        public User Add(User User)
        {
            return _UserRepository.Add(User);
        }

        public User Delete(int id)
        {
            return _UserRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _UserRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _UserRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(User User)
        {
            _UserRepository.Update(User);
        }
    }
}