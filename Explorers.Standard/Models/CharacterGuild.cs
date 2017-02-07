namespace WowDotNetAPI.Models
{
    public class CharacterGuild
    {
        public string Name { get; set; }

        public string Realm { get; set; }

        public int Level { get; set; }

        public int AchievementPoints { get; set; }

        public int Members { get; set; }

        public CharacterGuildEmblem Emblem { get; set; }
    }
}
