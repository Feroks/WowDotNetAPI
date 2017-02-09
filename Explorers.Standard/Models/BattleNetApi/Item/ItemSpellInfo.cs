namespace WowDotNetAPI.Models.BattleNetApi.Item
{
    public class ItemSpellInfo
    {
        public int SpellId { get; set; }
        
        public int NCharges { get; set; }
        
        public bool Consumable { get; set; }

        public int CategoryId { get; set; }

        public ItemSpell Spell { get; set; }
    }
}
