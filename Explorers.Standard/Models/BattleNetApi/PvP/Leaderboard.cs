using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.PvP
{
    public class Leaderboard
    {
        [JsonProperty("rows")]
        public IEnumerable<PvpStats> PvpStats { get; set; }
    }
}
