using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CharacterStats : IEnumerable
    {
        public int Health { get; set; }

        [JsonProperty("PowerType")]
        private string PowerTypeValue { get; set; }

        public int Power { get; set; }

        [JsonProperty("str")]
        public int Strength { get; set; }

        [JsonProperty("agi")]
        public int Agility { get; set; }

        [JsonProperty("int")]
        public int Intellect { get; set; }

        [JsonProperty("sta")]
        public int Stamina { get; set; }

        public double SpeedRating { get; set; }

        public double SpeedRatingBonus { get; set; }

        public double Crit { get; set; }

        public double CritRating { get; set; }

        public double Haste { get; set; }

        public double HasteRating { get; set; }

        public double HasteRatingPercent { get; set; }

        public double Mastery { get; set; }

        public double MasteryRating { get; set; }

        public int Spr { get; set; }

        public int BonusArmor { get; set; }

        public double Multistrike { get; set; }

        public double MultistrikeRating { get; set; }

        public double MultistrikeRatingBonus { get; set; }

        public double Leech { get; set; }

        public double LeechRating { get; set; }

        public double LeechRatingBonus { get; set; }

        public int Versatility { get; set; }

        public double VersatilityDamageDoneBonus { get; set; }

        public double VersatilityHealingDoneBonus { get; set; }

        public double VersatilityDamageTakenBonus { get; set; }

        public double AvoidanceRating { get; set; }

        public double AvoidanceRatingBonus { get; set; }

        public int SpellPower { get; set; }

        public int SpellPenetration { get; set; }

        public double SpellCrit { get; set; }

        public double SpellCritRating { get; set; }

        public double Mana5 { get; set; }

        public double Mana5Combat { get; set; }

        public int Armor { get; set; }

        public double Dodge { get; set; }

        public int DodgeRating { get; set; }

        public double Parry { get; set; }

        public int ParryRating { get; set; }

        public double Block { get; set; }

        public int BlockRating { get; set; }

        public double MainHandDmgMin { get; set; }

        public double MainHandDmgMax { get; set; }

        public double MainHandSpeed { get; set; }

        public double MainHandDps { get; set; }

        public double OffHandDmgMin { get; set; }

        public double OffHandDmgMax { get; set; }

        public double OffHandSpeed { get; set; }

        public double OffHandDps { get; set; }

        public double RangedDmgMin { get; set; }

        public double RangedDmgMax { get; set; }

        public double RangedSpeed { get; set; }

        public double RangedDps { get; set; }

        public int AttackPower { get; set; }

        public int RangedAttackPower { get; set; }

        public CharacterPowerType PowerType => (CharacterPowerType)Enum.Parse(typeof(CharacterPowerType), PowerTypeValue.Replace("-", string.Empty), true);

        //http://stackoverflow.com/questions/1447308/enumerating-through-an-objects-properties-string-in-c
        //TODO:REFACTOR THIS / possible performance issue
        public IEnumerator GetEnumerator()
        {
            var tmp =
                GetType()
                .GetTypeInfo()
                .DeclaredProperties
                .Select(pi => new KeyValuePair<string, object>(pi.Name, pi.GetMethod.Invoke(this, null)));

            return tmp.GetEnumerator();
        }
    }
}
