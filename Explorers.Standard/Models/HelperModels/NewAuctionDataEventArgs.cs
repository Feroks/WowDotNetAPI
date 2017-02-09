using System;

namespace WowDotNetAPI.Models.HelperModels
{
    public class NewAuctionDataEventArgs : EventArgs
    {
        internal NewAuctionDataEventArgs(RealmRegionPair realmRegionPair, DateTime dateTime)
        {
            RealmRegionPair = realmRegionPair;
            DateTime = dateTime;
        }
        public RealmRegionPair RealmRegionPair { get; }
        public DateTime DateTime { get; }
    }
}
