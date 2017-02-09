using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI.Repositories.Logic
{
    public class BaseRepository
    {
        private readonly IExplorer _explorer;

        protected BaseRepository(IExplorer explorer)
        {
            _explorer = explorer;
        }

        protected Region Region => _explorer.Region;
        protected Locale Locale => _explorer.Locale;
        protected string ApiKey => _explorer.ApiKey;
        protected string Host => Region.GetHost();

        protected static async Task<T> GetDataAsync<T>(string url) where T : class
        {
            return await JsonUtility.FromJsonAsync<T>(url);
        }
    }
}
