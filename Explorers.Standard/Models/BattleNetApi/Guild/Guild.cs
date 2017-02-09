using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WowDotNetAPI.Models.BattleNetApi.Achievement;

namespace WowDotNetAPI.Models.BattleNetApi.Guild
{
    public enum UnitSide
    {
        Alliance = 0,
        Horde = 1
    }
    
    public class Guild
    {
        public string Name { get; set; }

        public string Realm { get; set; }

        public string Battlegroup { get; set; }

        [JsonProperty("side")]
        private int SideValue { get; set; }

        public int Level { get; set; }

        public int AchievementPoints { get; set; }

        public long LastModified { get; set; }

        public GuildEmblem Emblem { get; set; }

        public IEnumerable<GuildMember> Members { get; set; }

        public Achievements Achievements { get; set; }

        public IEnumerable<GuildNews> News { get; set; }

        public UnitSide Side => (UnitSide)Enum.Parse(typeof(UnitSide), Enum.GetName(typeof(UnitSide), SideValue));
    }
}
