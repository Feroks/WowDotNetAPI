using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Item
{
    public class ItemGemType
    {
        [JsonProperty("type")]
        public string Color { get; set; }
    }
}
