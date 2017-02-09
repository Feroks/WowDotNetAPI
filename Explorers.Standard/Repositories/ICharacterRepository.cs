using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Character;

namespace WowDotNetAPI.Repositories
{
    public interface ICharacterRepository
    {
        Character GetCharacter(string realm, string name);
        Task<Character> GetCharacterAsync(string realm, string name);

        Character GetCharacter(string realm, string name, CharacterOptions characterOptions);
        Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions);

        Character GetCharacter(Region region, string realm, string name);
        Task<Character> GetCharacterAsync(Region region, string realm, string name);

        Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions);
        Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions);

        IEnumerable<CharacterRaceInfo> GetCharacterRaces();
        Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync();

        IEnumerable<CharacterClassInfo> GetCharacterClasses();
        Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync();
    }
}
