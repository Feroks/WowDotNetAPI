using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.Guild;

namespace WowDotNetAPI.Repositories
{
    public interface IGuildRepository
    {
        Guild GetGuild(string realm, string name);
        Task<Guild> GetGuildAsync(string realm, string name);

        Guild GetGuild(string realm, string name, GuildOptions guildOptions);
        Task<Guild> GetGuildAsync(string realm, string name, GuildOptions guildOptions);

        Guild GetGuild(Region region, string realm, string name);
        Task<Guild> GetGuildAsync(Region region, string realm, string name);

        Guild GetGuild(Region region, string realm, string name, GuildOptions guildOptions);
        Task<Guild> GetGuildAsync(Region region, string realm, string name, GuildOptions guildOptions);

        IEnumerable<GuildRewardInfo> GetGuildRewards();
        Task<IEnumerable<GuildRewardInfo>> GetGuildRewardsAsync();

        IEnumerable<GuildPerkInfo> GetGuildPerks();
        Task<IEnumerable<GuildPerkInfo>> GetGuildPerksAsync();
    }
}
