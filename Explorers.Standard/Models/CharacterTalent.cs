using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public enum CharacterSpec
    {
        MageArcane = 62,
        MageFire = 63,
        MakeFrost = 64,
        PaladinHoly = 65,
        PaladinProtection = 66,
        PaladinRetribution = 70,
        WarriorArms = 71,
        WarriorFury = 72,
        WarriorProtection = 73,
        PetFerocity = 74,
        PetCunning = 79,
        PetTenacity = 81,
        DruidBalance = 102,
        DruidFeral = 103,
        DruidGuardian = 104,
        DruidRestor = 105,
        DkBlood = 250,
        DkFrost = 251,
        DkUnholy = 252,
        HunterBeastmaster = 253,
        HunterMarksman = 254,
        HunterSurvival = 255,
        PriestDiscipline = 256,
        PriestHoly = 257,
        PriestShadow = 258,
        RogueAssassination = 259,
        RogueCombat = 260,
        RogueSubtlety = 261,
        ShamanElemental = 262,
        ShamanEnhancement = 263,
        ShamanRestoration = 264,
        WarlockAffliction = 265,
        WarlockDemonology = 266,
        WarlockDestruction = 267,
        MonkBrewmaster = 268,
        MonkWinddancer = 269,
        MonkMistweaver = 270,
        AdaptationFerocity = 535,
        AdaptationCunning = 536,
        AdaptationTenacity = 537
    }

    public class CharacterTalent
    {
        public bool Selected { get; set; }

        public IEnumerable<CharacterTalentInfo> Talents { get; set; }

        public CharacterTalentGlyphs Glyphs { get; set; }

        public CharacterTalentSpec Spec { get; set; }

        public string CalcTalent { get; set; }

        public string CalcSpec { get; set; }

        public string CalcGlyph { get; set; }
    }
}
