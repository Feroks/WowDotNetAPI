using WowDotNetAPI.Enums;
using WowDotNetAPI.Repositories;

namespace WowDotNetAPI
{
    public interface IExplorer
    {
        Region Region { get; }
        Locale Locale { get; }
        string ApiKey { get; }
        string Host { get; }

        IAchievmentRepository Achievment { get; }
        IAuctionRepository Auction { get; }
        IChallengeRepository Challenge { get; }
        ICharacterRepository Character { get; }
        IGuildRepository Guild { get; }
        IItemRepository Item { get; }
        IMiscRepository Misc { get; }
        IPetRepository Pet { get; }
        IPvpRepository Pvp { get; }
        IRealmRepository Realm { get; }
    }
}
