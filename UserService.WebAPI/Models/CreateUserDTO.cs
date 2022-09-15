using AutoMapper;
using UserService.Application.Common.Mappings;
using UserService.Application.Users.Commands.CreateUser;

namespace UserService.WebAPI.Models
{
    public class CreateUserDTO : IMapWith<CreateUserCommand>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDTO, CreateUserCommand>()
                .ForMember(uCommand => uCommand.FirstName,
                    opt => opt.MapFrom(uDTO => uDTO.FirstName))
                .ForMember(uCommand => uCommand.LastName,
                    opt => opt.MapFrom(uDTO => uDTO.LastName))
                .ForMember(uCommand => uCommand.Age,
                    opt => opt.MapFrom(uDTO => uDTO.Age));

        }
    }
}
