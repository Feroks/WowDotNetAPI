using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Realm
{
    public enum RealmType
    {
        [EnumMember(Value = "pve")]
        PVE,
        [EnumMember(Value = "pvp")]
        PVP,
        [EnumMember(Value = "rp")]
        RP,
        [EnumMember(Value = "rppvp")]
        RPPVP
    }

    //TODO: sort out issue with enum member n/a . It seems there's an issue with the forward slash and how we serialize and the try to parse it
    //[DataContract]
    //public enum RealmPopulation
    //{
    //    [EnumMember(Value = "low")]
    //    LOW,
    //    [EnumMember(Value = "medium")]
    //    MEDIUM,
    //    [EnumMember(Value = "high")]
    //    HIGH,
    //    [EnumMember(Value = "n/a")]
    //    NA
    //}

    public class Realm
    {
        [JsonProperty("type")]
        private string TypeValue { get; set; }

        public bool Queue { get; set; }

        public bool Status { get; set; }

        public string Population { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Battlegroup { get; set; }

        public string Locale { get; set; }

        public RealmType Type => (RealmType)Enum.Parse(typeof(RealmType), TypeValue, true);

        //See enum TODO comments
        //public RealmPopulation Population { get { return (RealmPopulation)Enum.Parse(typeof(RealmPopulation), population, true); } }
    }
}
