namespace WowDotNetAPI.Models
{
    public class AchievementReward
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Quality { get; set; }
        public ItemTooltipParameters TooltipParams { get; set; }
    }
}
