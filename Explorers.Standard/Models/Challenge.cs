using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class Challenge
    {
        public IEnumerable<ChallengeGroup> Groups { get; set; }
        public ChallengeMap Map { get; set; }
    }
}
