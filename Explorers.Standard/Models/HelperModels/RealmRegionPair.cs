namespace WowDotNetAPI.Models.HelperModels
{
    public class RealmRegionPair
    {
        internal RealmRegionPair(Region region, string realm)
        {
            Region = region;
            Realm = realm;
        }

        public Region Region { get; }
        public string Realm { get; }

        public string UniquId => $"{Region}_{Realm}";
    }
}
