using Newtonsoft.Json;
using WowDotNetAPI.Models.BattleNetApi.Item;

namespace WowDotNetAPI.Models.BattleNetApi.Achievement
{
    public class AchievementReward
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Description { get; set; }
        public int ItemLevel { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        //public Stats
        public ItemTooltipParameters TooltipParams { get; set; }
    }
}
