using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class ChallengeGroup
    {
        public string Date { get; set; }
        public string Faction { get; set; }
        public bool IsRecurring { get; set; }
        public string Medal { get; set; }
        public IEnumerable<ChallengeMember> Members { get; set; }
        public int Ranking { get; set; }
        public ChallengeTime Time { get; set; }
    }
}
