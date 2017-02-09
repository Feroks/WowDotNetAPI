using System;
using Newtonsoft.Json;
using WowDotNetAPI.Models.BattleNetApi.Character;

namespace WowDotNetAPI.Models.BattleNetApi.Challenge
{
    public class ChallengeMemberCharacter
    {
        public string Name { get; set; }
        public string Realm { get; set; }
        [JsonProperty("class")]
        private int ClassValue { get; set; }
        [JsonProperty("race")]
        private int RaceValue { get; set; }
        [JsonProperty("gender")]
        private int GenderValue { get; set; }
        public int Level { get; set; }
        public int AchievementPoints { get; set; }
        public string Thumbnail { get; set; }
        public string Guild { get; set; }
        public string Battlegroup { get; set; }
        
        public CharacterClass Class => (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), ClassValue).Replace(' ', '_'));
        public CharacterRace Race => (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), RaceValue).Replace(' ', '_'));
        public CharacterGender Gender => (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), GenderValue).Replace(' ', '_'));

        //TODO: cleanup 
        //probably better to override equality operators http://msdn.microsoft.com/en-us/library/ms173147.aspx
        public int CompareTo(Character.Character other)
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
