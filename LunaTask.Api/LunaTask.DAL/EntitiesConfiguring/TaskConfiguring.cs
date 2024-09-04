using LunaTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.DAL.EntitiesConfiguring
{
    public class TaskConfiguring : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Title).IsRequired();

            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.Priority)
                .HasConversion<string>();

            entity.HasOne<User>(x => x.User)
                  .WithMany(x => x.Tasks)
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
