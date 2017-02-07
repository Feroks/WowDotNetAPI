using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class CharacterPets
    {
        public int NumCollected { get; set; }

        public int NumNotCollected { get; set; }

        public IEnumerable<Pet> Collected { get; set; }
    }
}
