using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterMounts
    {
        public int NumCollected { get; set; }

        public int NumNotCollected { get; set; }
        
        public IEnumerable<CharacterMount> Collected { get; set; }        
    }
}
