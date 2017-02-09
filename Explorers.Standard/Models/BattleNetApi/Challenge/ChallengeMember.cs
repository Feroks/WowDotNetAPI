using WowDotNetAPI.Models.BattleNetApi.Character;

namespace WowDotNetAPI.Models.BattleNetApi.Challenge
{
    public class ChallengeMember
    {
        public ChallengeMemberCharacter Character { get; set; }
        public CharacterTalentSpec Spec { get; set; }
    }
}
