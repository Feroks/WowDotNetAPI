using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class AchievementCategory
    {
        public int Id { get; set; }
        public IEnumerable<AchievementInfo> Achievements { get; set; }
        public string Name { get; set; }
    }
}
