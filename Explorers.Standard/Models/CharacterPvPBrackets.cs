using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class CharacterPvPBrackets
    {
        [JsonProperty("ARENA_BRACKET_2v2")]
        public CharacterPvPBracket ArenaBracket2V2 { get; set; }

        [JsonProperty("ARENA_BRACKET_3v3")]
        public CharacterPvPBracket ArenaBracket3V3 { get; set; }

        [JsonProperty("ARENA_BRACKET_RBG")]
        public CharacterPvPBracket ArenaBracketRbg { get; set; }

        [JsonProperty("ARENA_BRACKET_2v2_SKIRMISH")]
        public CharacterPvPBracket ArenaBracket2V2Skirmish { get; set; }
    }
}
