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
        public long Bid { get; set; }
        public long Buyout { get; set; }
        public int Quantity { get; set; }
        public string TimeLeft { get; set; }
    }
}