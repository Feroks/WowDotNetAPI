using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi
{
    public class Recipe
    {
        [JsonProperty("id")]
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public string Profession { get; set; }

        public string Icon { get; set; }
    }
}
