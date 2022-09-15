using FluentValidation;

namespace UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(createUserCommand =>
                createUserCommand.LastName).NotEmpty().MaximumLength(100);
        }
    }
}
