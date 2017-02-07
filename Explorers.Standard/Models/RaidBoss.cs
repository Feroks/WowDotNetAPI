namespace WowDotNetAPI.Models
{
	public class RaidBoss
	{
		public string Name { get; set; }

        public int LfrKills { get; set; }

        public ulong LfrTimestamp { get; set; }

        public int NormalKills { get; set; }

        public ulong NormalTimestamp { get; set; }

        public int HeroicKills { get; set; }

        public ulong HeroicTimestamp { get; set; }

        public int MythicKills { get; set; }

        public ulong MythicrTimestamp { get; set; }

        public int Id { get; set; }
	}
}
