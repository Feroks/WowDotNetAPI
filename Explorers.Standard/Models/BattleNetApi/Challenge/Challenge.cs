using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Challenge
{
    public class Challenge
    {
        public IEnumerable<ChallengeGroup> Groups { get; set; }
        public ChallengeMap Map { get; set; }
    }
}
