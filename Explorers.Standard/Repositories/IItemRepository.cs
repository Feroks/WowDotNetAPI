using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Item;

namespace WowDotNetAPI.Repositories
{
    public interface IItemRepository
    {
        Item GetItem(int id);
        Task<Item> GetItemAsync(int id);

        IEnumerable<ItemClassInfo> GetItemClasses();
        Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync();
    }
}
