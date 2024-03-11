using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialFilm.Application.Features.Roles.Dtos;
using SocialFilm.Application.Features.Roles.Rules;

namespace SocialFilm.Application.Features.Roles.Commands;

public class CreateRoleCommand : IRequest<CreatedRoleDto>
{
    public string Name { get; set; }

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, CreatedRoleDto>
    {
        private readonly RoleBusinessRules _roleBusinessRules;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        
        public CreateRoleCommandHandler(RoleManager<Role> roleManager, IMapper mapper, RoleBusinessRules roleBusinessRules)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _roleBusinessRules = roleBusinessRules;
        }

        public async Task<CreatedRoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleBusinessRules.CheckIfRoleWithNameAlreadyExists(request.Name);
            
            Role newRole = _mapper.Map<Role>(request);
            await _roleManager.CreateAsync(newRole);

            return _mapper.Map<CreatedRoleDto>(newRole);
        }
    }
}