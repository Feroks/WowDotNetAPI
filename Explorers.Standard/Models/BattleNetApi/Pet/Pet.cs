namespace WowDotNetAPI.Models.BattleNetApi.Pet
{
    public class Pet
    {
        public int BattlePetId { get; set; }

        public bool CanBattle { get; set; }

        public long CreatureId { get; set; }

        public string CreatureName { get; set; }

        public string Icon { get; set; }

        public bool IsFavorite { get; set; }

        public string Name { get; set; }

        public int QualityId { get; set; }

        public long SpellId { get; set; }

        public PetStats Stats { get; set; }
    }
}
