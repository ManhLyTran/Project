using HVKTQS.Data.Infrastructure;
using HVKTQS.Model.Models;

namespace HVKTQS.Data.Repositories
{
    public interface IEventUserRepository : IRepository<EventUser>
    {
    }

    public class EventUserRepository : RepositoryBase<EventUser>, IEventUserRepository
    {
        public EventUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}