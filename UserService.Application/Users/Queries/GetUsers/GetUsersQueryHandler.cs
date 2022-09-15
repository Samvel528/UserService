using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserService.Application.Interfaces;

namespace UserService.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler
    : IRequestHandler<GetUsersQuery, UserListVM>
    {
        private readonly IUserServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserServiceDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserListVM> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var usersQuery = await _dbContext.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UserListVM { Users = usersQuery };
        }
    }
}
