using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public enum Bracket
    {
        _2V2,
        _3V3,
        _5V5,
        Rbg
    }

    public class Leaderboard
    {
        [JsonProperty("rows")]
        public IEnumerable<PvpStats> PvpStats { get; set; }
    }
}
