using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Configrations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(project => project.Id);

            builder.HasOne(project => project.Leader)
                   .WithMany(leader => leader.Projects)
                   .HasForeignKey(project => project.LeaderId);

            builder.HasMany(project => project.Tasks)
                   .WithOne(task => task.Project)
                   .HasForeignKey(task => task.ProjId);
        }
    }
}
