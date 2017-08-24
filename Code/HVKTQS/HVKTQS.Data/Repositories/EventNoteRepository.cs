using HVKTQS.Data.Infrastructure;
using HVKTQS.Model.Models;

namespace HVKTQS.Data.Repositories
{
    public interface IEventNoteRepository : IRepository<EventNote>
    {
    }

    public class EventNoteRepository : RepositoryBase<EventNote>, IEventNoteRepository
    {
        public EventNoteRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}