using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Common.Exceptions;
using UserService.Application.Interfaces;
using UserService.Domain;

namespace UserService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserServiceDbContext _dbContext;

        public UpdateUserCommandHandler(IUserServiceDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u =>
                              u.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Id);

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Age = request.Age;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
