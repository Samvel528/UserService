using FluentValidation;
using System;

namespace UserService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUserCommand => updateUserCommand.Id).NotEqual(Guid.Empty);
            RuleFor(UpdateUserCommand =>
                UpdateUserCommand.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(UpdateUserCommand =>
                UpdateUserCommand.LastName).NotEmpty().MaximumLength(100);
        }
    }
}
