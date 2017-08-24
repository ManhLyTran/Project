namespace HVKTQS.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private HVKTQSDbContext dbContext;

        public HVKTQSDbContext Init()
        {
            return dbContext ?? (dbContext = new HVKTQSDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}