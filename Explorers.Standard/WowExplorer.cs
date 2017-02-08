using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Models;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI
{
    public enum Region
    {
        Us,     //us.api.battle.net/
        Eu,     //eu.api.battle.net/
        Kr,     //kr.api.battle.net/
        Tw,     //tw.api.battle.net/
        Cn,     // ???
        Sea     //sea.api.battle.net/
    }

    public enum Locale
    {
        None,
        //US
        en_US,
        es_MX,
        pt_BR,
        //EU
        en_GB,
        de_DE,
        es_ES,
        fr_FR,
        it_IT,
        pl_PL,
        pt_PT,
        ru_RU,
        //KR
        ko_KR,
        //TW
        zh_TW,
        //CN
        zh_CN
    }

    [Flags]
    public enum CharacterOptions
    {
        None = 0,
        GetGuild = 1,
        GetStats = 2,
        GetTalents = 4,
        GetItems = 8,
        GetReputation = 16,
        GetTitles = 32,
        GetProfessions = 64,
        GetAppearance = 128,
        GetPetSlots = 256,
        GetMounts = 512,
        GetPets = 1024,
        GetAchievements = 2048,
        GetProgression = 4096,
        GetFeed = 8192,
        GetPvP = 16384,
        GetQuests = 32768,
        GetHunterPets = 65536,
        GetEverything = GetGuild | GetStats | GetTalents | GetItems | GetReputation | GetTitles
        | GetProfessions | GetAppearance | GetPetSlots | GetMounts | GetPets
        | GetAchievements | GetProgression | GetFeed | GetPvP | GetQuests | GetHunterPets
    }

    [Flags]
    public enum GuildOptions
    {
        None = 0,
        GetMembers = 1,
        GetAchievements = 2,
        GetNews = 4,
        GetEverything = GetMembers | GetAchievements | GetNews
    }

    public class WowExplorer : IExplorer
    {
        public event EventHandler OnAuctionDataUpdate;

        public Region Region { get; }
        public Locale Locale { get; }
        public string ApiKey { get; }

        public string Host { get; }

        public WowExplorer(Region region, Locale locale, string apiKey)
        {
            Region = region;
            Locale = locale;
            ApiKey = apiKey;

            switch (Region)
            {
                case Region.Eu:
                    Host = "https://eu.api.battle.net";
                    break;
                case Region.Kr:
                    Host = "https://kr.api.battle.net";
                    break;
                case Region.Tw:
                    Host = "https://tw.api.battle.net";
                    break;
                case Region.Cn:
                    Host = "https://www.battlenet.com.cn";
                    break;
                default:
                    Host = "https://us.api.battle.net";
                    break;
            }
        }

        #region Character

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
            return await GetDataAsync<Character>($@"{Host}/wow/character/{realm}/{name}?locale={Locale}{CharacterUtility.BuildOptionalQuery(characterOptions)}&apikey={ApiKey}");
        }

        #endregion

        #region Guild

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public async Task<Guild> GetGuildAsync(string realm, string name)
        {
            return await GetGuildAsync(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public async Task<Guild> GetGuildAsync(Region region, string realm, string name)
        {
            return await GetGuildAsync(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public async Task<Guild> GetGuildAsync(string realm, string name, GuildOptions realmOptions)
        {
            return await GetGuildAsync(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            return GetGuildAsync(region, realm, name, realmOptions).GetAwaiter().GetResult();
        }

        public async Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions realmOptions)
        {
            return await GetDataAsync<Guild>($@"{Host}/wow/guild/{realm}/{name}?locale={Locale}{GuildUtility.BuildOptionalQuery(realmOptions)}&apikey={ApiKey}");
        }

        #endregion

        #region Pets

        /// <summary>
        /// Gets a list of all battle pets
        /// </summary>
        /// <returns>PetList object containing an IEnumerable of Pet objects</returns>
        public IEnumerable<Pet> GetPets()
        {
            return GetPetsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {
            return (await GetDataAsync<PetList>($@"{Host}/wow/pet/?locale={Locale}&apikey={ApiKey}")).Pets;
        }

        /// <summary>
        /// Gets details on a specific Battle Pet ability
        /// </summary>
        /// <param name="id">The id of the ability to get details on.</param>
        /// <returns>Returns PetAbilityDetails object for the ability with the given id</returns>
        public PetAbilityDetails GetPetAbilityDetails(int id)
        {
            return GetPetAbilityDetailsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<PetAbilityDetails> GetPetAbilityDetailsAsync(int id)
        {
            return await GetDataAsync<PetAbilityDetails>($@"{Host}/wow/pet/ability/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Gets details on a specific [species of] Battle Pet
        /// </summary>
        /// <param name="id">The species ID of the battle pet</param>
        /// <returns>PetSpecies object containing details for the battle pet with the given species ID</returns>
        public PetSpecies GetPetSpeciesDetails(int id)
        {
            return GetPetSpeciesDetailsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<PetSpecies> GetPetSpeciesDetailsAsync(int id)
        {
            return await GetDataAsync<PetSpecies>($@"{Host}/wow/pet/species/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Retrieve detailed information about a given species of pet.
        /// </summary>
        /// <param name="speciesId">The pet's species ID. This can be found by querying a users' list of pets via the Character Profile API.</param>
        /// <param name="level">The pet's level. Pet levels max out at 25. If omitted the API assumes a default value of 1.</param>
        /// <param name="breedId">The pet's breed. Retrievable via the Character Profile API. If omitted the API assumes a default value of 3.</param>
        /// <param name="qualityId">The pet's quality. Retrievable via the Character Profile API. Pet quality can range from 0 to 5 (0 is poor quality and 5 is legendary). If omitted the API will assume a default value of 1.</param>
        /// <returns></returns>
        public PetStats GetPetStats(int speciesId, int level, int breedId, int qualityId)
        {
            return GetPetStatsAsync(speciesId, level, breedId, qualityId).GetAwaiter().GetResult();
        }

        public async Task<PetStats> GetPetStatsAsync(int speciesId, int level, int breedId, int qualityId)
        {
            return await GetDataAsync<PetStats>($@"{Host}/wow/pet/stats/{speciesId}?level={level}&breedId={breedId}&qualityId={qualityId}&locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PetType> GetPetTypes()
        {
            return GetPetTypesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<PetType>> GetPetTypesAsync()
        {
            var types = (await GetDataAsync<PetTypeData>($@"{Host}/wow/data/pet/types?locale={Locale}&apikey={ApiKey}")).PetTypes.ToList();
            return types.Any() ? types : null;
        }

        #endregion

        #region Mounts

        public IEnumerable<Mount> GetMounts()
        {
            return GetMountsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Mount>> GetMountsAsync()
        {
            return (await GetDataAsync<Mounts>($@"{Host}/wow/mount/?locale={Locale}&apikey={ApiKey}")).MountList;
        }

        #endregion

        #region Realms

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Locale.None);
        }

        public async Task<IEnumerable<Realm>> GetRealmsAsync()
        {
            return await GetRealmsAsync(Locale.None);
        }

        public IEnumerable<Realm> GetRealms(Locale locale)
        {
            return GetRealmsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Realm>> GetRealmsAsync(Locale locale)
        {
            var realmsData = await GetDataAsync<RealmsData>($@"{Host}/wow/realm/status?locale={Locale}&apikey={ApiKey}");
            if (realmsData == null)
            {
                return null;
            }
            return locale == Locale.None ? realmsData.Realms : realmsData.Realms.Where(x => x.Locale == locale.ToString());
        }

        #endregion

        #region Auctions

        public TimeSpan GetAuctionDataAge(string realm)
        {
            return GetAuctionDataAgeAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<TimeSpan> GetAuctionDataAgeAsync(string realm)
        {
            var snapShot = await GetAuctionFilesAsync(realm);
            return DateTime.Now - TimeSpan.FromMilliseconds(snapShot?.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified ?? 0).UnixToDateTime().ToLocalTime();
        }

        /// <summary>
        /// Gets a list of all current auctions on the given realm and connected realms
        /// </summary>
        /// <param name="realm">The name of the realm to base the search on</param>
        /// <returns>Auctions object for the given realm.</returns>
        public Auctions GetAuctions(string realm)
        {
            return GetAuctionsAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<Auctions> GetAuctionsAsync(string realm)
        {
            var auctionFiles = await GetAuctionFilesAsync(realm);

            if (auctionFiles == null) return null;
            var url = "";
            foreach (var auctionFile in auctionFiles.Files)
            {
                url = auctionFile.Url;
            }

            return await GetDataAsync<Auctions>(url);
        }

        private async Task<AuctionFiles> GetAuctionFilesAsync(string realm)
        {
            return await GetDataAsync<AuctionFiles>($@"{Host}/wow/auction/data/{realm.ToLower().Replace(' ', '-')}?locale={Locale}&apikey={ApiKey}");
        }

        #endregion

        #region Items
        public Item GetItem(int id)
        {
            return GetItemAsync(id).GetAwaiter().GetResult();
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await GetDataAsync<Item>($@"{Host}/wow/item/{id}?locale={Locale}&apikey={ApiKey}");
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            return GetItemClassesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync()
        {
            return (await GetDataAsync<ItemClassData>($@"{Host}/wow/data/item/classes?locale={Locale}&apikey={ApiKey}"))?.Classes;
        }

        #endregion

        #region CharacterRaceInfo
        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            return GetCharacterRacesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<CharacterRaceInfo>> GetCharacterRacesAsync()
        {
            return (await GetDataAsync<CharacterRacesData>($@"{Host}/wow/data/character/races?locale={Locale}&apikey={ApiKey}"))?.Races;
        }
        #endregion

        #region CharacterClassInfo
        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            return GetCharacterClassesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<CharacterClassInfo>> GetCharacterClassesAsync()
        {
            return (await GetDataAsync<CharacterClassesData>($@"{Host}/wow/data/character/classes?locale={Locale}&apikey={ApiKey}"))?.Classes;
        }
        #endregion

        #region GuildRewardInfo
        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            return GetGuildRewardsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync()
        {
            return (await GetDataAsync<GuildRewardsData>($@"{Host}/wow/data/guild/rewards?locale={Locale}&apikey={ApiKey}"))?.Rewards;
        }
        #endregion

        #region GuildPerkInfo
        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            return GetGuildPerksAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync()
        {
            return (await GetDataAsync<GuildPerksData>($@"{Host}/wow/data/guild/perks?locale={Locale}&apikey={ApiKey}"))?.Perks;
        }
        #endregion

        #region Achievements
        /// <summary>
        /// Gets details on a particular achievement
        /// </summary>
        /// <param name="id">The id of the achievement to get details on</param>
        /// <returns>AchievementInfo object for the achievement with the given id</returns>
        public AchievementInfo GetAchievement(int id)
        {
            return GetAchievementAsync(id).GetAwaiter().GetResult();
        }

        public async Task<AchievementInfo> GetAchievementAsync(int id)
        {
            return await GetDataAsync<AchievementInfo>($@"{Host}/wow/achievement/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Gets a list of all character achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetAchievements()
        {
            return GetAchievementsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<AchievementList>> GetAchievementsAsync()
        {
            return (await GetDataAsync<AchievementData>($@"{Host}/wow/data/character/achievements?locale={Locale}&apikey={ApiKey}"))?.Lists;
        }

        /// <summary>
        /// Gets a list of all guild achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            return GetGuildAchievementsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync()
        {
            return (await GetDataAsync<AchievementData>($@"{Host}/wow/data/guild/achievements?locale={Locale}&apikey={ApiKey}"))?.Lists;
        }

        #endregion

        #region Battlegroups
        public IEnumerable<BattlegroupInfo> GetBattlegroupsData()
        {
            return GetBattlegroupsDataAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync()
        {
            return (await GetDataAsync<BattlegroupData>($@"{Host}/wow/data/battlegroups/?locale={Locale}&apikey={ApiKey}"))?.Battlegroups;
        }
        #endregion

        #region Challenges

        /// <summary>
        /// The data in this request has data for all 9 challenge mode maps (currently). The map field includes the current medal times for each dungeon. Inside each ladder we provide data about each character that was part of each run. The character data includes the current cached spec of the character while the member field includes the spec of the character during the challenge mode run.
        /// </summary>
        /// <param name="realm">The realm being requested.</param>
        /// <returns></returns>
        public Challenges GetChallenges(string realm)
        {
            return GetChallengesAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<Challenges> GetChallengesAsync(string realm)
        {
            return await GetDataAsync<Challenges>($@"{Host}/wow/challenge/{realm}?locale={Locale}&apikey={ApiKey}");
        }
        #endregion

        #region Quests

        /// <summary>
        /// Retrieve metadata for a given quest.
        /// </summary>
        /// <param name="questId">The ID of the desired quest.</param>
        /// <returns></returns>
        public Quest GetQuestData(int questId)
        {
            return GetQuestDataAsync(questId).GetAwaiter().GetResult();
        }

        public async Task<Quest> GetQuestDataAsync(int questId)
        {
            return await GetDataAsync<Quest>($@"{Host}/wow/quest/{questId}?locale={Locale}&apikey={ApiKey}");
        }

        #endregion

        #region PvP
        public Leaderboard GetLeaderBoards(Bracket bracket)
        {
            return GetLeaderBoardsAsync(bracket).GetAwaiter().GetResult();
        }

        public async Task<Leaderboard> GetLeaderBoardsAsync(Bracket bracket)
        {
            return await GetDataAsync<Leaderboard>($@"{Host}/wow/leaderboard/{bracket.ToString().Replace("_", "")}?locale={Locale}&apikey={ApiKey}");
        }
        #endregion

        #region Recipes

        /// <summary>
        /// The recipe API provides basic recipe information.
        /// </summary>
        /// <param name="recipeId">Unique ID for the desired recipe.</param>
        /// <returns></returns>
        public Recipe GetRecipeData(int recipeId)
        {
            return GetRecipeDataAsync(recipeId).GetAwaiter().GetResult();
        }

        public async Task<Recipe> GetRecipeDataAsync(int recipeId)
        {
            return await GetDataAsync<Recipe>($@"{Host}/wow/recipe/{recipeId}?locale={Locale}&apikey={ApiKey}");
        }

        #endregion

        #region Spells

        /// <summary>
        /// The spell API provides some information about spells.
        /// </summary>
        /// <param name="spellId">Unique ID of the desired spell.</param>
        /// <returns></returns>
        public Spell GetSpellData(int spellId)
        {
            return GetSpellDataAsync(spellId).GetAwaiter().GetResult();
        }

        public async Task<Spell> GetSpellDataAsync(int spellId)
        {
            return await GetDataAsync<Spell>($@"{Host}/wow/spell/{spellId}?locale={Locale}&apikey={ApiKey}");
        }

        #endregion

        private static async Task<T> GetDataAsync<T>(string url) where T : class
        {
            return await JsonUtility.FromJsonAsync<T>(url);
        }

        public void StartMonitoringAuctionData(Region region, Realm realm, TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public void StopMonitoringAuctionDataAll(Region region, Realm realm)
        {
            throw new NotImplementedException();
        }

        public void StopMonitoringAuctionData(Region region, Realm realm)
        {
            throw new NotImplementedException();
        }
    }
}
