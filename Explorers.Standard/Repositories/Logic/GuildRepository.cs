using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Extensions;
using WowDotNetAPI.Models.BattleNetApi.Guild;
using WowDotNetAPI.Utilities;

namespace WowDotNetAPI.Repositories.Logic
{
    public class GuildRepository :BaseRepository, IGuildRepository
    {
        public GuildRepository(IExplorer explorer) : base(explorer)
        {
        }

        public Guild GetGuild(string realm, string name)
        {
            return GetGuild(Region, realm, name, GuildOptions.None);
        }

        public async Task<Guild> GetGuildAsync(string realm, string name)
        {
            return await GetGuildAsync(Region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(Region region, string realm, string name)
        {
            return GetGuild(region, realm, name, GuildOptions.None);
        }

        public async Task<Guild> GetGuildAsync(Region region, string realm, string name)
        {
            return await GetGuildAsync(region, realm, name, GuildOptions.None);
        }

        public Guild GetGuild(string realm, string name, GuildOptions realmOptions)
        {
            return GetGuild(Region, realm, name, realmOptions);
        }

        public async Task<Guild> GetGuildAsync(string realm, string name, GuildOptions realmOptions)
        {
            return await GetGuildAsync(Region, realm, name, realmOptions);
        }

        public Guild GetGuild(Region region, string realm, string name, GuildOptions realmOptions)
        {
            return GetGuildAsync(region, realm, name, realmOptions).GetAwaiter().GetResult();
        }

        public async Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions realmOptions)
        {
            return await GetDataAsync<Guild>($@"{region.GetHost()}/wow/guild/{realm}/{name}?locale={Locale}{GuildUtility.BuildOptionalQuery(realmOptions)}&apikey={ApiKey}");
        }

        public IEnumerable<GuildRewardInfo> GetGuildRewards()
        {
            return GetGuildRewardsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync()
        {
            return (await GetDataAsync<GuildRewardsData>($@"{Host}/wow/data/guild/rewards?locale={Locale}&apikey={ApiKey}"))?.Rewards;
        }

        public IEnumerable<GuildPerkInfo> GetGuildPerks()
        {
            return GetGuildPerksAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync()
        {
            return (await GetDataAsync<GuildPerksData>($@"{Host}/wow/data/guild/perks?locale={Locale}&apikey={ApiKey}"))?.Perks;
        }
    }
}