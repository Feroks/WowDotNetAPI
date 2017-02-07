using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
	public class CharacterTalentGlyphs
	{
        public IEnumerable<CharacterTalentGlyph> Major { get; set; }

        public IEnumerable<CharacterTalentGlyph> Minor { get; set; }
	}
}
