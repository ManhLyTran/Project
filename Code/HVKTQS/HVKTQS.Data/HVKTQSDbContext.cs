using HVKTQS.Model.Models;
using System.Data.Entity;

namespace HVKTQS.Data
{
    public class HVKTQSDbContext : DbContext
    {
        public HVKTQSDbContext() : base("HVKTQSConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Department> Departments { set; get; }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Event> Events { set; get; }
        public DbSet<EventFile> EventFiles { set; get; }
        public DbSet<EventNote> EventNotes { set; get; }
        public DbSet<EventUser> EventUsers { set; get; }
        public DbSet<Position> Positions { set; get; }
        public DbSet<Subject> Subjects { set; get; }
        public DbSet<User> User { set; get; }

        public static HVKTQSDbContext Create()
        {
            return new HVKTQSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<User>()
              .HasOptional(e => e.Employees)
              .WithRequired(e => e.Users);
        }
    }
}