using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Pet
{
    public class PetStats
    {
        public int BreedId { get; set; }

        public int Health { get; set; }

        public int Level { get; set; }

        [JsonProperty("petQualityId")]
        public int QualityId { get; set; }

        public int Power { get; set; }

        public int SpeciesId { get; set; }

        public int Speed { get; set; }
    }
}
