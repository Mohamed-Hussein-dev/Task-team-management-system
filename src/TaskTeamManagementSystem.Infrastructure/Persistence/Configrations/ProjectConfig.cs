using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Infrastructure.Persistence.Configrations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(project => project.Id);

            builder.HasOne(project => project.Leader)
                   .WithMany(leader => leader.LeadingProjects)
                   .HasForeignKey(project => project.LeaderId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(project => project.Tasks)
                   .WithOne(task => task.Project)
                   .HasForeignKey(task => task.ProjId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(project => project.Memebers)
                   .WithMany(member => member.ProjectMemberships)
                   .UsingEntity<Dictionary<string, object>>(
                    "UsersProjects",
                    j => j.HasOne<AppUser>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.Cascade),
                    j =>{j.HasKey("UserId", "ProjectId"); }
                    );
        }
    }
}
