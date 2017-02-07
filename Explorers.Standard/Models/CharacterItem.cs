using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
	public class CharacterItem
	{
		public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Quality { get; set; }

		public int ItemLevel { get; set; }

        public ItemTooltipParameters TooltipParams { get; set; }

		public IEnumerable<ItemStat> Stats { get; set; }

		public int Armor { get; set; }

		public string Context { get; set; }

		public IEnumerable<int> BonusLists { get; set; }

		// Legion
		public int ArtifactId { get; set; }

		public IEnumerable<CharacterItemArtifactTrait> ArtifactTraits { get; set; }

		public IEnumerable<CharacterItemRelic> Relics { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
