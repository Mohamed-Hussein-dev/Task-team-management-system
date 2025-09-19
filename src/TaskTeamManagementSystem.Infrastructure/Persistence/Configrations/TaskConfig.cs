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
    public class TaskConfig : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(task => task.Id);

            builder.HasOne(task => task.AssigneeUser)
                   .WithMany(user => user.Tasks)
                   .HasForeignKey(task => task.AssigneeUserId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(task => task.Project)
                   .WithMany(project => project.Tasks)
                   .HasForeignKey(task => task.ProjId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
