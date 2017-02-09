using System.Collections.Generic;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Auction
{
    public class Auctions
    {
        [JsonProperty("realms")]
        public IEnumerable<Realm.Realm> Realm { get; set; }
        [JsonProperty("auctions")]
        public IEnumerable<Auction> CurrentAuctions { get; set; }
    }
}
