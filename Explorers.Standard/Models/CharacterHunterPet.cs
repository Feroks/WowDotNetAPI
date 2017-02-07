using System.Runtime.Serialization;

namespace WowDotNetAPI.Models
{
    [DataContract]
    public class CharacterHunterPet
    {
        public string CalcSpec { get; set; }

        public long Creature { get; set; }

        public int FamilyId { get; set; }

        public string FamilyName { get; set; }

        public string Name { get; set; }

        public bool Selected { get; set; }

        public int Slot { get; set; }

        public CharacterTalentSpec Spec { get; set; }
    }
}
