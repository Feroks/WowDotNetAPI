using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Item
{
    public class ItemGemBonusInfo
    {
        public string Name { get; set; }

        [JsonProperty("srcItemId")]
        public int SourceItemId { get; set; }

        public int RequiredSkillId { get; set; }

        public int RequiredSkillRank { get; set; }

        public int MinLevel { get; set; }

        public int ItemLevel { get; set; }
    }
}
