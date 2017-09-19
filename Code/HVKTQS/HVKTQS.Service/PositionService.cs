using System;
using System.Collections.Generic;
using HVKTQS.Data.Infrastructure;
using HVKTQS.Data.Repositories;
using HVKTQS.Model.Models;

namespace HVKTQS.Service
{
    public interface IPositionService
    {
        Position Add(Position Position);

        void Update(Position Position);

        Position Delete(int id);

        IEnumerable<Position> GetAll();

        Position GetById(int id);

        void Save();
    }

    public class PositionService : IPositionService
    {
        private IPositionRepository _PositionRepository;
        private IUnitOfWork _unitOfWork;

        public PositionService(IPositionRepository PositionRepository, IUnitOfWork unitOfWork)
        {
            this._PositionRepository = PositionRepository;
            this._unitOfWork = unitOfWork;
        }

        public Position Add(Position Position)
        {
            return _PositionRepository.Add(Position);
        }

        public Position Delete(int id)
        {
            return _PositionRepository.Delete(id);
        }

        public IEnumerable<Position> GetAll()
        {
            return _PositionRepository.GetAll();
        }

        public Position GetById(int id)
        {
            return _PositionRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Position Position)
        {
            _PositionRepository.Update(Position);
        }
    }
}