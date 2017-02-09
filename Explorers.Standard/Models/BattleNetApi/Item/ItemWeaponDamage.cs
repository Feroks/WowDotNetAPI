using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Item
{
    public class ItemWeaponDamage
    {
        [JsonProperty("min")]
        public int MinDamage { get; set; }

        [JsonProperty("max")]
        public int MaxDamage { get; set; }
    }
}
