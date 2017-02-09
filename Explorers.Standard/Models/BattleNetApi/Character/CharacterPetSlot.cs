using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterPetSlot
    {
        public IEnumerable<int> Abilities { get; set; }

        public int BattlePetId { get; set; }

        public bool IsEmpty { get; set; }

        public bool IsLocked { get; set; }

        public int Slot { get; set; }
    }
}
