using FluentValidation;

namespace SocialFilm.Application.Features.Roles.Commands;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(2);
        RuleFor(x => x.Name).MaximumLength(50);
    }
}