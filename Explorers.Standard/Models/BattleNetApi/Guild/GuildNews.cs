using WowDotNetAPI.Models.BattleNetApi.Achievement;

namespace WowDotNetAPI.Models.BattleNetApi.Guild
{
    public class GuildNews
    {
        public string Type { get; set; }

        public string Character { get; set; }

        public long Timestamp { get; set; }

        public int ItemId { get; set; }

        public AchievementInfo Achievement { get; set; }

        public int LevelUp { get; set; }
    }
}
