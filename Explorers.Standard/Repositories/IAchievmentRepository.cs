using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Achievement;

namespace WowDotNetAPI.Repositories
{
    public interface IAchievmentRepository
    {
        AchievementInfo GetAchievement(int id);
        Task<AchievementInfo> GetAchievementAsync(int id);

        IEnumerable<AchievementList> GetAchievements();
        Task<IEnumerable<AchievementList>> GetAchievementsAsync();

        IEnumerable<AchievementList> GetGuildAchievements();
        Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync();
    }
}
