using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Backend_Project.Dtos.Character;
using Backend_Project.Services.CharacterService;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using AutoMapper;
//using Backend_Project.Data;
//using Backend_Project.Dtos.Character;
//using Microsoft.EntityFrameworkCore;

namespace Backend_Project.Controllers.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
                  new Character(),
                  new Character {Id = 1 ,Name = "Aboodi"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);

            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try
            {


                Character character = characters.First(c => c.Id == id);

                characters.Remove(character);
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }

            return response;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ServiceResponse<List<GetCharacterDto>>
            {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
            };
        }


        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacaterDto updateCharacater)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {


                Character character = characters.FirstOrDefault(c => c.Id == updateCharacater.Id);

                // _mapper.Map(updateCharacater, character);
                character.Name = updateCharacater.Name;
                character.HitPoints = updateCharacater.HitPoints;
                character.Strength = updateCharacater.Strength;
                character.Defense = updateCharacater.Defense;
                character.Intellingence = updateCharacater.Intellingence;
                character.Class = updateCharacater.Class;


                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }

            return response;

        }
    }
}