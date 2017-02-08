using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class Auction
    {
        [JsonProperty("auc")]
        public int Id { get; set; }
        [JsonProperty("item")]
        public long ItemId { get; set; }
        public string Owner { get; set; }
        public string OwnerRealm { get; set; }
        public long Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public int Rand { get; set; }
        public int Seed { get; set; }
        public int Context { get; set; }
        public string TimeLeft { get; set; }
    }
}