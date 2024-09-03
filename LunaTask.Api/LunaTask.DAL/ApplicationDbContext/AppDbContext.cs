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


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateDate();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateDate()
        {
            var entities = ChangeTracker.Entries()
                 .Where(e => e.Entity != null && e.Entity.GetType().GetProperty("CreatedAt") != null
                 && e.Entity.GetType().GetProperty("UpdateAt") != null);

            foreach (var entity in entities)
            {
                var entityType = entity.GetType();

                if (entity.State == EntityState.Added)
                {
                    entityType.GetProperty("CreatedAt")?.SetValue(entity.Entity, DateTime.UtcNow);
                }
                entityType.GetProperty("UpdateAt")?.SetValue(entity.Entity, DateTime.UtcNow);
            }
        }

    }
}
