using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Realm;

namespace WowDotNetAPI.Repositories
{
    public interface IRealmRepository
    {
        IEnumerable<Realm> GetRealms();
        Task<IEnumerable<Realm>> GetRealmsAsync();

        IEnumerable<Realm> GetRealms(Locale locale);
        Task<IEnumerable<Realm>> GetRealmsAsync(Locale locale);
    }
}
