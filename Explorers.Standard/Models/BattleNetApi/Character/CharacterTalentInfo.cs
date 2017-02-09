namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterTalentInfo
    {
        public int Tier { get; set; }

        public int Column { get; set; }

        public CharacterTalentSpell Spell { get; set; }
    }
}
