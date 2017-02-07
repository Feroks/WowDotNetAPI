 using System;
 using System.Runtime.Serialization;
 using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public enum CharacterPowerType
    {
        [EnumMember(Value = "focus")]
        FOCUS,
        [EnumMember(Value = "rage")]
        RAGE,
        [EnumMember(Value = "mana")]
        MANA,
        [EnumMember(Value = "energy")]
        ENERGY,
        [EnumMember(Value = "runic-power")]
        RUNICPOWER
    }

    [DataContract]
    public class CharacterClassInfo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "mask")]
        public int Mask { get; set; }

        [JsonProperty("powerType")]
        private string PowerTypeValue { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        public CharacterPowerType PowerType => (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), PowerTypeValue.Replace("-", string.Empty), true);
    }
}
