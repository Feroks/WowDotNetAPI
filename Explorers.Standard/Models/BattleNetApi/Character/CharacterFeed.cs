using WowDotNetAPI.Models.BattleNetApi.Achievement;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterFeed
    {
        public string Type { get; set; }

        public long Timestamp { get; set; }

        public AchievementInfo Achievement { get; set; }

        public bool FeatOfStrength { get; set; }

        public AchievementCriteria Criteria { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public int ItemId { get; set; }

        public string Context { get; set; }

        public int[] BonusLists { get; set; }
    }
}
