using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
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

    public class CharacterClassInfo
    {
        public int Id { get; set; }

        public int Mask { get; set; }

        [JsonProperty("powerType")]
        private string PowerTypeValue { get; set; }

        public string Name { get; set; }

        public CharacterPowerType PowerType => (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), PowerTypeValue.Replace("-", string.Empty), true);
    }
}
