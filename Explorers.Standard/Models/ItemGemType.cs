using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class ItemGemType
    {
        [JsonProperty("type")]
        public string Color { get; set; }
    }
}
