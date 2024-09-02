using LunaTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaTask.DAL.EntitiesConfiguring
{
    public class UserConfiguring : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Username)
                  .IsRequired();

            entity.HasIndex(x => x.Username)
                  .IsUnique();

            entity.Property(x => x.Email)
                  .IsRequired();

            entity.HasIndex(x => x.Email)
                  .IsUnique();

            entity.Property(x=>x.PasswordHash)
                  .IsRequired();
        }
    }
}
