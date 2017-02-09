using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Guild
{
    public class GuildRewardInfo
    {
        public int MinGuildLevel { get; set; }

        public int MinGuildRepLevel { get; set; }

        public IEnumerable<int> Races { get; set; }

        public GuildRewardAchievementInfo Achievement { get; set; }

        public GuildRewardItemInfo Item { get; set; }
    }
}
