﻿using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Achievement
{
    public class AchievementCategory
    {
        public int Id { get; set; }
        public IEnumerable<AchievementInfo> Achievements { get; set; }
        public string Name { get; set; }
    }
}
