using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class AchievementData
    {
        [JsonProperty("achievements")]
        public IEnumerable<AchievementList> Lists { get; set; }
    }
}
