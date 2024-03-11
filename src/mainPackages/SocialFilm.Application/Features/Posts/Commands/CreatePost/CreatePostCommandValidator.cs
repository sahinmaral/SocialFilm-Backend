using FluentValidation;

namespace SocialFilm.Application.Features.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());

        RuleFor(x => x.FilmId)
            .NotEmpty()
            .NotEqual(Guid.Empty.ToString());

        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(10000);

        RuleFor(x => x.Photos.Count)
            .NotEqual(0);
        
        RuleFor(x => x.Photos.First().Length)
            .NotEqual(0);
    }
    
}