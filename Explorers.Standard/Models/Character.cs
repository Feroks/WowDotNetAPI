using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum CharacterClass
    {
        WARRIOR = 1,
        PALADIN = 2,
        HUNTER = 3,
        ROGUE = 4,
        PRIEST = 5,
        DEATH_KNIGHT = 6,
        SHAMAN = 7,
        MAGE = 8,
        WARLOCK = 9,
        MONK = 10,
        DRUID = 11,
        DEMONHUNTER = 12
    }

    [DataContract]
    public enum CharacterRace
    {
        HUMAN = 1,
        ORC = 2,
        DWARF = 3,
        NIGHT_ELF = 4,
        UNDEAD = 5,
        TAUREN = 6,
        GNOME = 7,
        TROLL = 8,
        GOBLIN = 9,
        BLOOD_ELF = 10,
        DRAENEI = 11,
        WORGEN = 22,
        PANDAREN_NEUTRAL = 24,
        PANDAREN_ALLIANCE = 25,
        PANDAREN_HORDE = 26
    }

    [DataContract]
    public enum CharacterGender
    {
        MALE = 0,
        FEMALE = 1
    }

    public class Character : IComparable<Character>
    {
        public string LastModified { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }

        [JsonProperty("class")]
        private int ClassValue { get; set; }

        [JsonProperty("race")]
        private int RaceValue { get; set; }

        [JsonProperty("Gender")]
        private int GenderValue { get; set; }
        public int Level { get; set; }
        public int AchievementPoints { get; set; }
        public char CalcClass { get; set; }
        public string Thumbnail { get; set; }
        public CharacterGuild Guild { get; set; }
        public CharacterStats Stats { get; set; }
        public IEnumerable<CharacterTalent> Talents { get; set; }
        public CharacterEquipment Items { get; set; }
        public IEnumerable<CharacterReputation> Reputation { get; set; }
        public IEnumerable<CharacterTitle> Titles { get; set; }
        public CharacterProfessions Professions { get; set; }
        public Achievements Achievements { get; set; }
        public CharacterAppearance Appearance { get; set; }
        public CharacterMounts Mounts { get; set; }
        public IEnumerable<CharacterHunterPet> HunterPets { get; set; }
        public CharacterPets Pets { get; set; }
        public IEnumerable<CharacterPetSlot> PetSlots { get; set; }
        public Progression Progression { get; set; }
        public IEnumerable<CharacterFeed> Feed { get; set; }
        public CharacterPvP PvP { get; set; }
        public IEnumerable<int> Quests { get; set; }
        public CharacterStatistics Statistics { get; set; }
        public int TotalHonorableKills { get; set; }

        [JsonIgnore]
        public CharacterClass Class => (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), ClassValue).Replace(' ', '_'));

        [JsonIgnore]
        public CharacterRace Race => (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), RaceValue).Replace(' ', '_'));

        [JsonIgnore]
        public CharacterGender Gender => (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), GenderValue).Replace(' ', '_'));

        //TODO: cleanup 
        //probably better to override equality operators http://msdn.microsoft.com/en-us/library/ms173147.aspx
        public int CompareTo(Character other)
        {
            if (Name == other.Name
                && Realm == other.Realm
                && Class == other.Class
                && Race == other.Race
                && Gender == other.Gender)
            {
                return 0;
            }

            return -1;
        }
    }
}
