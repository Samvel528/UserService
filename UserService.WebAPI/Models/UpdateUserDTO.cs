using AutoMapper;
using System;
using UserService.Application.Common.Mappings;
using UserService.Application.Users.Commands.UpdateUser;

namespace UserService.WebAPI.Models
{
    public class UpdateUserDTO : IMapWith<UpdateUserCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDTO, UpdateUserCommand>()
                .ForMember(uCommand => uCommand.Id,
                    opt => opt.MapFrom(uDTO => uDTO.Id))
                .ForMember(uCommand => uCommand.FirstName,
                    opt => opt.MapFrom(uDTO => uDTO.FirstName))
                .ForMember(uCommand => uCommand.LastName,
                    opt => opt.MapFrom(uDTO => uDTO.LastName))
                .ForMember(uCommand => uCommand.Age,
                    opt => opt.MapFrom(uDTO => uDTO.Age));
        }
    }
}
