using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Item
{
	public class ItemTooltipParameters 
	{
        public int Gem0 { get; set; }
        
        public int Gem1 { get; set; }
        
        public int Gem2 { get; set; }

        public int Enchant { get; set; }

        public int Reforge { get; set; }

        public IEnumerable<int> Set { get; set; }

        public long Seed { get; set; }

        public bool ExtraSocket { get; set; }

        public int Suffix { get; set; }

		public ItemUpgrade ItemUpgrade { get; set; }

        public int TimeWalkerLevel { get; set; }
	}
}
