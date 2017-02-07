using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string NameDescription { get; set; }

        public string Name { get; set; }

        public int Stackable { get; set; }

        public IEnumerable<int> AllowableClasses { get; set; }

        public int ItemBind { get; set; }

        public IEnumerable<ItemBonusStat> BonusStats { get; set; }

        public string Icon { get; set; }

        public IEnumerable<ItemSpellInfo> ItemSpells { get; set; }

        public int BuyPrice { get; set; }

        public int ItemClass { get; set; }

        public int ItemSubClass { get; set; }

        public int ContainerSlots { get; set; }

        public ItemGemInfo GemInfo { get; set; }

        public ItemWeaponInfo WeaponInfo { get; set; }

        public int InventoryType { get; set; }

        public bool Equippable { get; set; }

        public int ItemLevel { get; set; }

        public int MaxCount { get; set; }

        public int MaxDurability { get; set; }

        public int MinFactionId { get; set; }

        public int MinReputation { get; set; }

        public int Quality { get; set; }

        public int SellPrice { get; set; }

        public int RequiredSkill { get; set; }

        public int RequiredLevel { get; set; }
         
        public int RequiredSkillRank { get; set; }

        public ItemSocketInfo SocketInfo { get; set; }

        public ItemSourceInfo ItemSource { get; set; }

        public int BaseArmor { get; set; }

        public bool HasSockets { get; set; }

        public bool IsAuctionable { get; set; }

        public bool Upgradable { get; set; }

        public int DisenchantingSkillRank { get; set; }

        public int DisplayInfoId { get; set; }

        public bool HeroicTooltip { get; set; }

        public string NameDescriptionColor { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
