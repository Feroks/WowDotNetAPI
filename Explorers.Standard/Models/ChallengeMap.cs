namespace WowDotNetAPI.Models
{
    public class ChallengeMap
    {
        public ChallengeTime GoldCriteria { get; set; }
        public ChallengeTime SilverCriteria { get; set; }
        public ChallengeTime BronzeCriteria { get; set; }
        public int Id { get; set; }
        public bool HasChallengeMode { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
