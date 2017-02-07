using System;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class GuildCharacter
    {
        public string LastModified { get; set; }

        public string Name { get; set; }

        public string Realm { get; set; }

		public string GuildRealm { get; set; }

        [JsonProperty("class")]
        private int ClassValue { get; set; }

        [JsonProperty("race")]
        private int RaceValue { get; set; }

        [JsonProperty("gender")]
        private int GenderValue { get; set; }

        public int Level { get; set; }

        public int AchievementPoints { get; set; }

        public string Thumbnail { get; set; }

        [JsonProperty("spec")]
        public GuildCharacterSpec Specialization { get; set; }

        public CharacterClass Class => (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), ClassValue).Replace(' ', '_'));
        public CharacterRace Race => (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), RaceValue).Replace(' ', '_'));
        public CharacterGender Gender => (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), GenderValue).Replace(' ', '_'));
    }
}
