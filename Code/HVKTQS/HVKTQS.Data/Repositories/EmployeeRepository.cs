using HVKTQS.Data.Infrastructure;
using HVKTQS.Model.Models;

namespace HVKTQS.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }

    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}