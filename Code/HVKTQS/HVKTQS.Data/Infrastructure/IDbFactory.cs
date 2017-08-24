using System;

namespace HVKTQS.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        HVKTQSDbContext Init();
    }
}