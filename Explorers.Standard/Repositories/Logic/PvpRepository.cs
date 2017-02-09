using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.PvP;

namespace WowDotNetAPI.Repositories.Logic
{
    public class PvpRepository :BaseRepository, IPvpRepository
    {
        public PvpRepository(IExplorer explorer) : base(explorer)
        {
        }

        public IEnumerable<BattlegroupInfo> GetBattlegroupsData()
        {
            return GetBattlegroupsDataAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync()
        {
            return (await GetDataAsync<BattlegroupData>($@"{Host}/wow/data/battlegroups/?locale={Locale}&apikey={ApiKey}"))?.Battlegroups;
        }

        public Leaderboard GetLeaderBoards(Bracket bracket)
        {
            return GetLeaderBoardsAsync(bracket).GetAwaiter().GetResult();
        }

        public async Task<Leaderboard> GetLeaderBoardsAsync(Bracket bracket)
        {
            return await GetDataAsync<Leaderboard>($@"{Host}/wow/leaderboard/{bracket.ToString().Replace("_", "")}?locale={Locale}&apikey={ApiKey}");
        }
    }
}