namespace WowDotNetAPI.Models
{
    public class GuildRewardItemInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Quality { get; set; }

        public ItemTooltipParameters TooltipParams { get; set; }
    }
}
