using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Common.Exceptions;
using UserService.Application.Interfaces;
using UserService.Domain;

namespace UserService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserServiceDbContext _dbContext;

        public DeleteUserCommandHandler(IUserServiceDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(/*new object[] { request.Id }*/ request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
