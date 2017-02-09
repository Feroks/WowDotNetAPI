using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Achievement
{
    public class AchievementList
    {
        public int Id { get; set; }
        public IEnumerable<AchievementInfo> Achievements { get; set; }
        public IEnumerable<AchievementCategory> Categories { get; set; }
        public string Name { get; set; }
    }
}
