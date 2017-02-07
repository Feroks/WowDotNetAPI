using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public enum Bracket
    {
        _2v2,
        _3v3,
        _5v5,
        rbg
    }

    public class Leaderboard
    {
        [JsonProperty("rows")]
        public IEnumerable<PvpStats> PvpStats { get; set; }
    }
}
