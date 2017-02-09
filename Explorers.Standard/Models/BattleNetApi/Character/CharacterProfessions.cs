using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
	public class CharacterProfessions
	{
		public IEnumerable<CharacterProfession> Primary { get; set; }

        public IEnumerable<CharacterProfession> Secondary { get; set; }
	}
}
