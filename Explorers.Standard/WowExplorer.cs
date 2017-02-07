using System;
using System.Collections.Generic;
using System.Linq;
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
        public Region Region { get; set; }
        public Locale Locale { get; set; }
        public string ApiKey { get; set; }

        public string Host { get; set; }

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

        public Character GetCharacter(Region region, string realm, string name)
        {
            return GetCharacter(region, realm, name, CharacterOptions.None);
        }

        public Character GetCharacter(string realm, string name, CharacterOptions characterOptions)
        {
            return GetCharacter(Region, realm, name, characterOptions);
        }

        public Character GetCharacter(Region region, string realm, string name, CharacterOptions characterOptions)
        {
            TryGetData($@"{Host}/wow/character/{realm}/{name}?locale={Locale}{CharacterUtility.BuildOptionalQuery(characterOptions)}&apikey={ApiKey}", out Character character);
            return character;
        }

        #endregion

        #region Guild

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            TryGetData($@"{Host}/wow/guild/{realm}/{name}?locale={Locale}{GuildUtility.BuildOptionalQuery(realmOptions)}&apikey={ApiKey}", out Guild guild);
            return guild;
        }

        #endregion

        #region Pets

        /// <summary>
        /// Gets a list of all battle pets
        /// </summary>
        /// <returns>PetList object containing an IEnumerable of Pet objects</returns>
        public IEnumerable<Pet> GetPets()
        {
            TryGetData($@"{Host}/wow/pet/?locale={Locale}&apikey={ApiKey}", out PetList pets);
            return pets.Pets;
        }

        /// <summary>
        /// Gets details on a specific Battle Pet ability
        /// </summary>
        /// <param name="id">The id of the ability to get details on.</param>
        /// <returns>Returns PetAbilityDetails object for the ability with the given id</returns>
        public PetAbilityDetails GetPetAbilityDetails(int id)
        {
            TryGetData($@"{Host}/wow/pet/ability/{id}?locale={Locale}&apikey={ApiKey}", out PetAbilityDetails ability);
            return ability;
        }

        /// <summary>
        /// Gets details on a specific [species of] Battle Pet
        /// </summary>
        /// <param name="id">The species ID of the battle pet</param>
        /// <returns>PetSpecies object containing details for the battle pet with the given species ID</returns>
        public PetSpecies GetPetSpeciesDetails(int id)
        {
            TryGetData($@"{Host}/wow/pet/species/{id}?locale={Locale}&apikey={ApiKey}", out PetSpecies species);
            return species;
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
            TryGetData($@"{Host}/wow/pet/stats/{speciesId}?level={level}&breedId={breedId}&qualityId={qualityId}&locale={Locale}&apikey={ApiKey}", out PetStats stats);
            return stats;
        }

        /// <summary>
        /// The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PetType> GetPetTypes()
        {
            TryGetData($@"{Host}/wow/data/pet/types?locale={Locale}&apikey={ApiKey}", out PetTypeData types);
            return types.PetTypes.Any() ? types.PetTypes : null;
        }

        #endregion

        #region Mounts

        public IEnumerable<Mount> GetMounts()
        {
            TryGetData($@"{Host}/wow/mount/?locale={Locale}&apikey={ApiKey}", out Mounts mounts);
            return mounts.MountList;
        }

        #endregion

        #region Realms
        public IEnumerable<Realm> GetRealms(Locale locale)
        {
            TryGetData($@"{Host}/wow/realm/status?locale={Locale}&apikey={ApiKey}", out RealmsData realmsData);
            if (realmsData == null)
            {
                return null;
            }
            return locale == Locale.None ? realmsData.Realms : realmsData.Realms.Where(x => x.Locale == locale.ToString());
        }

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Locale.None);
        }

        #endregion

        #region Auctions

        public TimeSpan GetAuctionDataAge(string realm)
        {
            TryGetData($@"{Host}/wow/auction/data/{realm.ToLower().Replace(' ', '-')}?locale={Locale}&apikey={ApiKey}", out AuctionSnapshot snapshot);
            return DateTime.Now - TimeSpan.FromMilliseconds(snapshot?.Files.OrderBy(x => x.LastModified).FirstOrDefault()?.LastModified ?? 0).UnixToDateTime().ToLocalTime();
        }

        /// <summary>
        /// Gets a list of all current auctions on the given realm and connected realms
        /// </summary>
        /// <param name="realm">The name of the realm to base the search on</param>
        /// <returns>Auctions object for the given realm.</returns>
        public Auctions GetAuctions(string realm)
        {
            TryGetData($@"{Host}/wow/auction/data/{realm.ToLower().Replace(' ', '-')}?locale={Locale}&apikey={ApiKey}", out AuctionFiles auctionFiles);

            if (auctionFiles == null) return null;
            var url = "";
            foreach (var auctionFile in auctionFiles.Files)
            {
                url = auctionFile.Url;
            }

            TryGetData(url, out Auctions auctions);
            return auctions;
        }

        #endregion

        #region Items
        public Item GetItem(int id)
        {
            TryGetData($@"{Host}/wow/item/{id}?locale={Locale}&apikey={ApiKey}", out Item item);
            return item;
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            TryGetData($@"{Host}/wow/data/item/classes?locale={Locale}&apikey={ApiKey}", out ItemClassData itemclassdata);
            return itemclassdata?.Classes;
        }

        #endregion

        #region CharacterRaceInfo
        public IEnumerable<CharacterRaceInfo> GetCharacterRaces()
        {
            TryGetData($@"{Host}/wow/data/character/races?locale={Locale}&apikey={ApiKey}", out CharacterRacesData charRacesData);
            return charRacesData?.Races;
        }
        #endregion

        #region CharacterClassInfo
        public IEnumerable<CharacterClassInfo> GetCharacterClasses()
        {
            TryGetData($@"{Host}/wow/data/character/classes?locale={Locale}&apikey={ApiKey}", out CharacterClassesData characterClasses);
            return characterClasses?.Classes;
        }
        #endregion

        #region GuildRewardInfo
        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            TryGetData($@"{Host}/wow/data/guild/rewards?locale={Locale}&apikey={ApiKey}", out GuildRewardsData guildRewardsData);

            return guildRewardsData?.Rewards;
        }
        #endregion

        #region GuildPerkInfo
        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            TryGetData($@"{Host}/wow/data/guild/perks?locale={Locale}&apikey={ApiKey}", out GuildPerksData guildPerksData);
            return guildPerksData?.Perks;
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
            TryGetData($@"{Host}/wow/achievement/{id}?locale={Locale}&apikey={ApiKey}", out AchievementInfo achievement);
            return achievement;
        }

        /// <summary>
        /// Gets a list of all character achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetAchievements()
        {
            TryGetData($@"{Host}/wow/data/character/achievements?locale={Locale}&apikey={ApiKey}", out AchievementData achievementData);
            return achievementData?.Lists;
        }

        /// <summary>
        /// Gets a list of all guild achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            TryGetData($@"{Host}/wow/data/guild/achievements?locale={Locale}&apikey={ApiKey}", out AchievementData achievementData);
            return achievementData?.Lists;
        }

        #endregion

        #region Battlegroups
        public IEnumerable<BattlegroupInfo> GetBattlegroupsData()
        {
            TryGetData($@"{Host}/wow/data/battlegroups/?locale={Locale}&apikey={ApiKey}", out BattlegroupData battlegroupData);
            return battlegroupData?.Battlegroups;
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
            TryGetData($@"{Host}/wow/challenge/{realm}?locale={Locale}&apikey={ApiKey}", out Challenges challenges);
            return challenges;
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
            TryGetData($@"{Host}/wow/quest/{questId}?locale={Locale}&apikey={ApiKey}", out Quest quest);
            return quest;
        }

        #endregion

        #region PvP
        public Leaderboard GetLeaderBoards(Bracket bracket)
        {
            TryGetData($@"{Host}/wow/leaderboard/{bracket.ToString().Replace("_", "")}?locale={Locale}&apikey={ApiKey}", out Leaderboard pvpRows);
            return pvpRows;
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
            TryGetData($@"{Host}/wow/recipe/{recipeId}?locale={Locale}&apikey={ApiKey}", out Recipe recipe);
            return recipe;
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
            TryGetData($@"{Host}/wow/spell/{spellId}?locale={Locale}&apikey={ApiKey}", out Spell spell);
            return spell;
        }

        #endregion

        private static bool TryGetData<T>(string url, out T requestedObject) where T : class
        {
            try
            {
                requestedObject = JsonUtility.FromJson<T>(url);
                return true;
            }
            catch (Exception)
            {
                requestedObject = null;
                return false;
            }
        }
    }
}
