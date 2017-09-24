using HVKTQS.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HVKTQS.Data
{
    public class HVKTQSDbContext : IdentityDbContext<ApplicationUser>
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

        public DbSet<Error> Errors { set; get; }
        //public DbSet<ApplicationUser> ApplicationUser { set; get; }

        public static HVKTQSDbContext Create()
        {
            return new HVKTQSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
    }
}