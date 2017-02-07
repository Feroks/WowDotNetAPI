namespace WowDotNetAPI.Models
{
    public class ChallengeTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Milliseconds { get; set; }
        public long Time { get; set; }

        public string TimeString
        {
            get
            {
                var tmp = Seconds + "." + Milliseconds + "s";

                if (Minutes > 0 || Hours > 0) { tmp = Minutes + "m " + tmp; }
                if (Hours > 0) { tmp += Hours + "h " + tmp; }

                return tmp;
            }
        }

    }
}
