﻿using System.Collections.Generic;

namespace WowDotNetAPI.Models
{
    public class CharacterStatistics
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CharacterStatisticsSubcategory> SubCategories { get; set; }
    }
}