using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class Quest
    {
        [JsonProperty("id")]
        public int QuestId { get; set; }

        public string Title { get; set; }

        public int RequiredLevel { get; set; }

        public int SuggestedPartyMembers { get; set; }

        public string Category { get; set; }

        public int Level { get; set; }
    }
}
