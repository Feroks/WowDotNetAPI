using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Achievement
{
    public class AchievementData
    {
        [JsonProperty("achievements")]
        public IEnumerable<AchievementList> Lists { get; set; }
    }
}
