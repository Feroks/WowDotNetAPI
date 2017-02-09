using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Models.BattleNetApi.Character;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI.Repositories.Logic
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        public CharacterRepository(IExplorer explorer) : base(explorer)
        {
        }

        public Character GetCharacter(string realm, string name)
        {
            return GetCharacter(Region, realm, name, CharacterOptions.None);
        }

        public async Task<Character> GetCharacterAsync(string realm, string name)
        {
            return await GetCharacterAsync(Region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(Region region, string realm, string name)
        {
            return GetCharacter(region, realm, name, CharacterOptions.None);
        }

        public async Task<Character> GetCharacterAsync(Region region, string realm, string name)
        {
            return await GetCharacterAsync(region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacter(Region, realm, name, characterOptions);
        }

        public async Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions)
        {
            return await GetCharacterAsync(Region, realm, name, characterOptions);
        }

        public Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacterAsync(region, realm, name, characterOptions).GetAwaiter().GetResult();
        }

        public async Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            return await GetDataAsync<Character>($@"{region.GetHost()}/wow/character/{realm}/{name}?locale={Locale}{CharacterUtility.BuildOptionalQuery(characterOptions)}&apikey={ApiKey}");
        }

        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            return GetCharacterRacesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync()
        {
            return (await GetDataAsync<CharacterRacesData>($@"{Host}/wow/data/character/races?locale={Locale}&apikey={ApiKey}"))?.Races;
        }

        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            return GetCharacterClassesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync()
        {
            return (await GetDataAsync<CharacterClassesData>($@"{Host}/wow/data/character/classes?locale={Locale}&apikey={ApiKey}"))?.Classes;
        }
    }
}
