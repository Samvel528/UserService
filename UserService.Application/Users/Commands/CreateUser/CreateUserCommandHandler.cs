using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Interfaces;
using UserService.Domain;

namespace UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserServiceDbContext _dbContext;

        public CreateUserCommandHandler(IUserServiceDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
