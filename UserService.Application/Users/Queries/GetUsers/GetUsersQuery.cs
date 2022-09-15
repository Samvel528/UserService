using MediatR;

namespace UserService.Application.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UserListVM>
    {
    }
}
