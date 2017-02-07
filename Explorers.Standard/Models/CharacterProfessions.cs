using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
	public class CharacterProfessions
	{
		public IEnumerable<CharacterProfession> Primary { get; set; }

        public IEnumerable<CharacterProfession> Secondary { get; set; }
	}
}
