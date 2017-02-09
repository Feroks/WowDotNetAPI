using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Enums;
using WowDotNetAPI.Models.BattleNetApi.PvP;

namespace WowDotNetAPI.Repositories
{
    public interface IPvpRepository
    {
        IEnumerable<BattlegroupInfo> GetBattlegroupsData();
        Task<IEnumerable<BattlegroupInfo>> GetBattlegroupsDataAsync();

        Leaderboard GetLeaderBoards(Bracket bracket);
        Task<Leaderboard> GetLeaderBoardsAsync(Bracket bracket);
    }
}
