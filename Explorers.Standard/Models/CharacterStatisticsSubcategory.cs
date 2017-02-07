using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class CharacterStatisticsSubcategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CharacterStatisticEntry> StatisticEntries { get; set; }

        public IEnumerable<CharacterStatisticsSubcategory> SubCategories { get; set; }
    }
}