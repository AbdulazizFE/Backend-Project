using Backend_Project.Dtos.Character;
using Backend_Project.Services.CharacterService;

namespace Backend_Project.Controllers.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacaterDto updateCharacater);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}