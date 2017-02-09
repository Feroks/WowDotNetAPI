using System.Collections.Generic;
using Newtonsoft.Json;
using WowDotNetAPI.Enums;

namespace WowDotNetAPI.Models.BattleNetApi.Achievement
{
    public class AchievementInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public IEnumerable<AchievementReward> RewardItems { get; set; }
        public string Icon { get; set; }
        [JsonProperty("factionId")]
        public Faction Faction { get; set; }
        public IEnumerable<AchievementCriteria> Criteria { get; set; }
        public bool AccountWide { get; set; }
    }
}
