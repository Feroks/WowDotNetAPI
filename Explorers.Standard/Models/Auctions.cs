using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class Auctions
    {
        public Realm Realm { get; set; }
        [JsonProperty("auctions")]
        public IEnumerable<Auction> CurrentAuctions { get; set; }
    }
}
