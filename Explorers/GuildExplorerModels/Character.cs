﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WowDotNetAPI.Explorers.GuildExplorerModels
{
    public class Character
    {
        public string lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
    }
}