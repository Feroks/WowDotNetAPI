using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Mount
{
    public class Mounts
    {
        [JsonProperty("mounts")]
        public IEnumerable<Mount> MountList { get; set; } 
    }
}
