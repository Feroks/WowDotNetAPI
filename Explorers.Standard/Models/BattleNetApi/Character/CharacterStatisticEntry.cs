namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterStatisticEntry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Quantity { get; set; }

        public long LastUpdated { get; set; }

        public bool Money { get; set; }
    }
}
