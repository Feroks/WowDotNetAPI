using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models;
using WowDotNetAPI.Models.HelperModels;

namespace WowDotNetAPI
{
    public interface IExplorer
    {
        event EventHandler<NewAuctionDataEventArgs> OnAuctionDataUpdate;

        Region Region { get; }
        Locale Locale { get; }
        string ApiKey { get; }

        string Host { get; }

        Character GetCharacter(string realm, string name);
        Task<Character> GetCharacterAsync(string realm, string name);

        Character GetCharacter(string realm, string name, CharacterOptions characterOptions);
        Task<Character> GetCharacterAsync(string realm, string name, CharacterOptions characterOptions);

        Character GetCharacter(Region region, string realm, string name);
        Task<Character> GetCharacterAsync(Region region, string realm, string name);

        Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions);
        Task<Character> GetCharacterAsync(Region region, string realm, string name, CharacterOptions characterOptions);

        Guild GetGuild(string realm, string name);
        Task<Guild> GetGuildAsync(string realm, string name);

        Guild GetGuild(string realm, string name, GuildOptions guildOptions);
        Task<Guild> GetGuildAsync(string realm, string name, GuildOptions guildOptions);

        Guild GetGuild(Region region, string realm, string name);
        Task<Guild> GetGuildAsync(Region region, string realm, string name);

        Guild GetGuild(Region region, string realm, string name, GuildOptions guildOptions);
        Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions guildOptions);

        IEnumerable<Pet> GetPets();
        Task<IEnumerable<Pet>> GetPetsAsync();

        PetAbilityDetails GetPetAbilityDetails(int id);
        Task<PetAbilityDetails> GetPetAbilityDetailsAsync(int id);

        PetSpecies GetPetSpeciesDetails(int id);
        Task<PetSpecies> GetPetSpeciesDetailsAsync(int id);

        PetStats GetPetStats(int speciesId, int level, int breedId, int qualityId);
        Task<PetStats> GetPetStatsAsync(int speciesId, int level, int breedId, int qualityId);

        IEnumerable<PetType> GetPetTypes();
        Task<IEnumerable<PetType>> GetPetTypesAsync();

        IEnumerable<Mount> GetMounts();
        Task<IEnumerable<Mount>> GetMountsAsync();

        AchievementInfo GetAchievement(int id);
        Task<AchievementInfo> GetAchievementAsync(int id);

        IEnumerable<AchievementList> GetAchievements();
        Task<IEnumerable<AchievementList>> GetAchievementsAsync();

        IEnumerable<AchievementList> GetGuildAchievements();
        Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync();

        IEnumerable<BattlegroupInfo> GetBattlegroupsData();
        Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync();

        IEnumerable<ItemClassInfo> GetItemClasses();
        Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync();

        IEnumerable<Realm> GetRealms();
        Task<IEnumerable<Realm>> GetRealmsAsync();

        IEnumerable<Realm> GetRealms(Locale locale);
        Task<IEnumerable<Realm>> GetRealmsAsync(Locale locale);

        TimeSpan GetAuctionDataAge(string realm);
        Task<TimeSpan> GetAuctionDataAgeAsync(string realm);

        TimeSpan GetAuctionDataAge(Region region, string realm);
        Task<TimeSpan> GetAuctionDataAgeAsync(Region region, string realm);

        Auctions GetAuctions(string realm);
        Task<Auctions> GetAuctionsAsync(string realm);

        Item GetItem(int id);
        Task<Item> GetItemAsync(int id);

        IEnumerable<CharacterRaceInfo> GetCharacterRaces();
        Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync();

        IEnumerable<CharacterClassInfo> GetCharacterClasses();
        Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync();

        IEnumerable<GuildRewardInfo> GetGuildRewards();
        Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync();

        IEnumerable<GuildPerkInfo> GetGuildPerks();
        Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync();

        Challenges GetChallenges(string realm);
        Task<Challenges> GetChallengesAsync(string realm);

        Quest GetQuestData(int questId);
        Task<Quest> GetQuestDataAsync(int questId);

        Leaderboard GetLeaderBoards(Bracket bracket);
        Task<Leaderboard> GetLeaderBoardsAsync(Bracket bracket);

        Recipe GetRecipeData(int recipeId);
        Task<Recipe> GetRecipeDataAsync(int recipeId);

        Spell GetSpellData(int spellId);
        Task<Spell> GetSpellDataAsync(int spellId);


        void StartMonitoringAuctionData(Region region, string realm, TimeSpan timeSpan);

        void StopMonitoringAuctionData(Region region, string realm);
        void StopMonitoringAuctionDataAll();
    }
}
