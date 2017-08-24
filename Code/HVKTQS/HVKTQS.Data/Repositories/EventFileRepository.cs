using HVKTQS.Data.Infrastructure;
using HVKTQS.Model.Models;

namespace HVKTQS.Data.Repositories
{
    public interface IEventFileRepository : IRepository<EventFile>
    {
    }

    public class EventFileRepository : RepositoryBase<EventFile>, IEventFileRepository
    {
        public EventFileRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}