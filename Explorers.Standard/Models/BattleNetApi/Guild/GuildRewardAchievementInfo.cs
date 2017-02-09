namespace WowDotNetAPI.Models.BattleNetApi.Guild
{
    public class GuildRewardAchievementInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public string Reward { get; set; }

        public GuildRewardItemInfo RewardItem { get; set; }
    }
}
