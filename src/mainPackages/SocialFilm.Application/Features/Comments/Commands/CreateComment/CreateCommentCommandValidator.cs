using FluentValidation;

namespace SocialFilm.Application.Features.Comments.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.PostId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());
        
        RuleFor(x => x.Message)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(10000);
        
        RuleFor(u => u.ParentCommentId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString())
            .When(u => !string.IsNullOrEmpty(u.ParentCommentId));
    }
}