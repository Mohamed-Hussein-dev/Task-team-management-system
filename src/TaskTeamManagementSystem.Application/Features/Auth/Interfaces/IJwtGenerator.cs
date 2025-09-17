using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTeamManagementSystem.Domain.Entities.Identtity;

namespace TaskTeamManagementSystem.Application.Features.Auth.Interfaces
{
    public interface IJwtGenerator
    {
        Task<string> GenerateJwtAsync(AppUser user , UserManager<AppUser> userManager);
    }
}
