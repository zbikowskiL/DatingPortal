using System.Linq;
using AutoMapper;
using DatingPortal.API.Dtos;
using DatingPortal.API.Models;

namespace DatingPortal.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, options =>
                {
                    options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, options =>
                {
                    options.ResolveUsing(src => src.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetalisDto>().ForMember(dest => dest.PhotoUrl, options =>
                {
                    options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age, options =>
                {
                    options.ResolveUsing(src => src.DateOfBirth.CalculateAge());
                });
            CreateMap<Photo, PhotosForDetailsDto>();
        }
    }
}