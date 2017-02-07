using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class Achievements
    {
        public IEnumerable<int> AchievementsCompleted { get; set; }
        public IEnumerable<long> AchievementsCompletedTimestamp { get; set; }
        public IEnumerable<int> Criteria { get; set; }
        public IEnumerable<long> CriteriaQuantity { get; set; }
        public IEnumerable<long> CriteriaTimestamp { get; set; }
        public IEnumerable<long> CriteriaCreated { get; set; }
    }
}
