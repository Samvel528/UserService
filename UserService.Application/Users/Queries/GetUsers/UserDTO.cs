using AutoMapper;
using System;
using UserService.Application.Common.Mappings;
using UserService.Domain;

namespace UserService.Application.Users.Queries.GetUsers
{
    public class UserDTO : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDTO>()
                .ForMember(uDTO => uDTO.Id,
                    opt => opt.MapFrom(u => u.Id))
                .ForMember(uDTO => uDTO.FirstName,
                    opt => opt.MapFrom(u => u.FirstName))
                .ForMember(uDTO => uDTO.LastName,
                    opt => opt.MapFrom(u => u.LastName))
                .ForMember(uDTO => uDTO.Age,
                    opt => opt.MapFrom(u => u.Age));
        }
    }
}
