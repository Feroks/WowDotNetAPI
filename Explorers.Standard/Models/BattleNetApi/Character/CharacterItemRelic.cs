﻿using System.Collections.Generic;

namespace WowDotNetAPI.Models.BattleNetApi.Character
{
    public class CharacterItemRelic
    {
        public int Socket { get; set; }

        public int ItemId { get; set; }

        public int Context { get; set; }

        public IEnumerable<int> BonusLists { get; set; }
    }
}
