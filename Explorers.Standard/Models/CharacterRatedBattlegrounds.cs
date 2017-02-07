using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class CharacterRatedBattlegrounds
    {
        public int PersonalRating { get; set; }

        public IEnumerable<CharacterRatedBattleground> Battlegrounds { get; set; }
    }
}
