using AutoMapper;
using Backend_Project.Dtos.Character;
using Backend_Project.Services.CharacterService;

namespace Backend_Project
{
    public class AutoMapperProfile : Profile
    {
     public AutoMapperProfile()
     {
         CreateMap<Character, GetCharacterDto>();
         CreateMap<AddCharacterDto, Character>();
         CreateMap<UpdateCharacaterDto, Character>();
     }   
    }
}