using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Realm;

namespace WowDotNetAPI.Repositories.Logic
{
    public class RealmRepository : BaseRepository, IRealmRepository
    {
        public RealmRepository(IExplorer explorer) : base(explorer)
        {
        }

        public IEnumerable<Realm> GetRealms()
        {
            return GetRealms(Locale.None);
        }

        public async Task<IEnumerable<Realm>> GetRealmsAsync()
        {
            return await GetRealmsAsync(Locale.None);
        }

        public IEnumerable<Realm> GetRealms(Locale locale)
        {
            return GetRealmsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Realm>> GetRealmsAsync(Locale locale)
        {
            var realmsData = await GetDataAsync<RealmsData>($@"{Host}/wow/realm/status?locale={Locale}&apikey={ApiKey}");
            if (realmsData == null)
            {
                return null;
            }
            return locale == Locale.None ? realmsData.Realms : realmsData.Realms.Where(x => x.Locale == locale.ToString());
        }
    }
}