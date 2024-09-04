using LunaTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LunaTask.DAL.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }


        public DbSet<User> Users { get; set; }
        public DbSet<LunaTask.DAL.Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }


       

    }
}
