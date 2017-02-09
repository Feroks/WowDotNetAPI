using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Pet
{
    public class PetAbilityDetails
    {
        [JsonProperty("id")]
        public int AbilityId { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Cooldown { get; set; }

        public int Rounds { get; set; }

        public int PetTypeId { get; set; }

        public bool IsPassive { get; set; }

        public bool HideHints { get; set; }
    }
}
