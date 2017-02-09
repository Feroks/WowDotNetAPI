using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Item;

namespace WowDotNetAPI.Repositories.Logic
{
    public class ItemRepository :BaseRepository, IItemRepository
    {
        public ItemRepository(IExplorer explorer) : base(explorer)
        {
        }

        public Item GetItem(int id)
        {
            return GetItemAsync(id).GetAwaiter().GetResult();
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await GetDataAsync<Item>($@"{Host}/wow/item/{id}?locale={Locale}&apikey={ApiKey}");
        }

        public IEnumerable<ItemClassInfo> GetItemClasses()
        {
            return GetItemClassesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ItemClassInfo>> GetItemClassesAsync()
        {
            return (await GetDataAsync<ItemClassData>($@"{Host}/wow/data/item/classes?locale={Locale}&apikey={ApiKey}"))?.Classes;
        }
    }
}