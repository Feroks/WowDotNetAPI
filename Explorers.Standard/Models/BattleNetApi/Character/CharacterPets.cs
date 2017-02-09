using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterPets
    {
        public int NumCollected { get; set; }

        public int NumNotCollected { get; set; }

        public IEnumerable<Pet.Pet> Collected { get; set; }
    }
}
