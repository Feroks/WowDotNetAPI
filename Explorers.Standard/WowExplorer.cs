using WowDotNetAPI.Enums;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Repositories;
using WowDotNetAPI.Repositories.Logic;

namespace WowDotNetAPI
{
    public class WowExplorer : IExplorer
    {
        public WowExplorer(Region region, Locale locale, string apiKey)
        {
            Region = region;
            Locale = locale;
            ApiKey = apiKey;

            Achievment = new AchievementRepository(this);
            Auction = new AuctionRepository(this);
            Character = new CharacterRepository(this);
            Challenge = new ChallengeRepository(this);
            Guild = new GuildRepository(this);
            Item = new ItemRepository(this);
            Pet = new PetRepository(this);
            Realm = new RealmRepository(this);
            Pvp = new PvpRepository(this);
            Misc = new MiscRepository(this);
        }

        public IAchievmentRepository Achievment { get; }
        public IAuctionRepository Auction { get; }
        public IChallengeRepository Challenge { get; }
        public ICharacterRepository Character { get; }
        public IGuildRepository Guild { get; }
        public IItemRepository Item { get; }
        public IMiscRepository Misc { get; }
        public IPetRepository Pet { get; }
        public IPvpRepository Pvp { get; }
        public IRealmRepository Realm { get; }

        public Region Region { get; }
        public Locale Locale { get; }
        public string ApiKey { get; }
        public string Host => Region.GetHost();
    }
}
