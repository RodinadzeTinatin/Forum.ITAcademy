using AutoMapper;
using Forum.Entities;
using Forum.Models;
using Forum.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public static class MappingInitializer
    {
        public static IMapper Initialize()
        {
            MapperConfiguration configuration = new(config =>
            {
                config.CreateMap<Topic, TopicForCreatingDto>().ReverseMap();
                config.CreateMap<Topic, TopicForGettingDto>().ReverseMap();
                config.CreateMap<Topic, TopicForUpdatingDto>().ReverseMap();


                config.CreateMap<Comment,  CommentForCreatingDto>().ReverseMap();
                config.CreateMap<Comment, CommentForGettingDto>().ReverseMap();
                config.CreateMap<Comment, CommentForUpdatingDto>().ReverseMap();

                config.CreateMap<UserDto, ApplicationUser>().ReverseMap();
                config.CreateMap<RegistrationRequestDto, ApplicationUser>()
                .ForMember(destination => destination.UserName, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedUserName, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Email))
                .ForMember(destination => destination.NormalizedEmail, options => options.MapFrom(source => source.Email.ToUpper()))
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Name));


            });

            return configuration.CreateMapper();
        }
    }
}
