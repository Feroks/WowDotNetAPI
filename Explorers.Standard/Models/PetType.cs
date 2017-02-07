using Newtonsoft.Json;

namespace WowDotNetAPI.Models
{
    public class PetType
    {
        [JsonProperty("id")]
        public int PetTypeId { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public int TypeAbilityId { get; set; }

        public int StrongAgainstId { get; set; }

        public int WeakAgainstId { get; set; }
    }
}
