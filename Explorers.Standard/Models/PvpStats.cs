using System;
using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class PvpStats
    {
        public int Ranking { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public int RealmId { get; set; }

        public string RealmName { get; set; }

        public string RealmSlug { get; set; }

        private int RaceId { get; set; }

        private int ClassId { get; set; }

        private int SpecId { get; set; }

        public int FactionId { get; set; }

        private int GenderId { get; set; }

        public int SeasonWins { get; set; }

        public int SeasonLosses { get; set; }

        public int WeeklyWins { get; set; }

        public int WeeklyLosses { get; set; }

        public CharacterClass Class => (CharacterClass)Enum.Parse(typeof(CharacterClass), Enum.GetName(typeof(CharacterClass), ClassId).Replace(' ', '_'));
        public CharacterRace Race => (CharacterRace)Enum.Parse(typeof(CharacterRace), Enum.GetName(typeof(CharacterRace), RaceId).Replace(' ', '_'));
        public CharacterGender Gender => (CharacterGender)Enum.Parse(typeof(CharacterGender), Enum.GetName(typeof(CharacterGender), GenderId).Replace(' ', '_'));
        public CharacterSpec Spec => (CharacterSpec)Enum.Parse(typeof(CharacterSpec), Enum.GetName(typeof(CharacterSpec), SpecId).Replace(' ', '_'));
    }
}
