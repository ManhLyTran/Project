using HVKTQS.Data.Infrastructure;
using HVKTQS.Model.Models;

namespace HVKTQS.Data.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
    }

    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}