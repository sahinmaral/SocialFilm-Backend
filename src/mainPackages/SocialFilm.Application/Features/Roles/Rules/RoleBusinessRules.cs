using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Microsoft.AspNetCore.Identity;

namespace SocialFilm.Application.Features.Roles.Rules;

public class RoleBusinessRules
{
    private readonly RoleManager<Role> _roleManager;

    public RoleBusinessRules(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CheckIfRoleWithNameAlreadyExists(string name)
    {
        Role? foundRole = await _roleManager.FindByNameAsync(name);
        if (foundRole is not null)
            throw new BusinessException("This role is already saved");
    }
}