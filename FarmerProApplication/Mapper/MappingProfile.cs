using AutoMapper;
using FarmerProApplication.Dtos.Cow;
using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Dtos.User;
using FarmerProApplication.Model.DatabaseModels;
using FarmerProApplication.Models.DatabaseModels;

namespace FarmerProApplication.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();

            CreateMap<Norm, NormDto>();
            CreateMap<CreateNormDto, Norm>();

            CreateMap<Korm, KormDto>();
            CreateMap<CreateKormDto, Korm>();

            CreateMap<Cow, CowDto>();
            CreateMap<CreateCowDto, Cow>();
        }
    }
}
