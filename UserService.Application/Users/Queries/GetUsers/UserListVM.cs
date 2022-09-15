using System.Collections.Generic;

namespace UserService.Application.Users.Queries.GetUsers
{
    public class UserListVM
    {
        public IList<UserDTO> Users { get; set; }
    }
}
