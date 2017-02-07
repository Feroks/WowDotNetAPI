using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public enum CharacterClass
    {
        Warrior = 1,
        Paladin = 2,
        Hunter = 3,
        Rogue = 4,
        Priest = 5,
        DeathKnight = 6,
        Shaman = 7,
        Mage = 8,
        Warlock = 9,
        Monk = 10,
        Druid = 11,
        Demonhunter = 12
    }

    public enum CharacterRace
    {
        Human = 1,
        Orc = 2,
        Dwarf = 3,
        NightElf = 4,
        Undead = 5,
        Tauren = 6,
        Gnome = 7,
        Troll = 8,
        Goblin = 9,
        BloodElf = 10,
        Draenei = 11,
        Worgen = 22,
        PandarenNeutral = 24,
        PandarenAlliance = 25,
        PandarenHorde = 26
    }

    public enum CharacterGender
    {
        Male = 0,
        Female = 1
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
