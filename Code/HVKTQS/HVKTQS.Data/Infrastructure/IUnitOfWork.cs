namespace HVKTQS.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}