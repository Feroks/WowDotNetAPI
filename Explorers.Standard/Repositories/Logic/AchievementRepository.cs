using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Achievement;

namespace WowDotNetAPI.Repositories.Logic
{
    internal class AchievementRepository : BaseRepository, IAchievmentRepository
    {
        internal AchievementRepository(IExplorer explorer) :base (explorer)
        {
        }

        /// <summary>
        /// Gets details on a particular achievement
        /// </summary>
        /// <param name="id">The id of the achievement to get details on</param>
        /// <returns>AchievementInfo object for the achievement with the given id</returns>
        public AchievementInfo GetAchievement(int id)
        {
            return GetAchievementAsync(id).GetAwaiter().GetResult();
        }

        public async Task<AchievementInfo> GetAchievementAsync(int id)
        {
            return await GetDataAsync<AchievementInfo>($@"{Host}/wow/achievement/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Gets a list of all character achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetAchievements()
        {
            return GetAchievementsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<AchievementList>> GetAchievementsAsync()
        {
            return (await GetDataAsync<AchievementData>($@"{Host}/wow/data/character/achievements?locale={Locale}&apikey={ApiKey}"))?.Lists;
        }

        /// <summary>
        /// Gets a list of all guild achievements
        /// </summary>
        /// <returns>IEnumerable containing AchievementList items for each achievement</returns>
        public IEnumerable<AchievementList> GetGuildAchievements()
        {
            return GetGuildAchievementsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<AchievementList>> GetGuildAchievementsAsync()
        {
            return (await GetDataAsync<AchievementData>($@"{Host}/wow/data/guild/achievements?locale={Locale}&apikey={ApiKey}"))?.Lists;
        }
    }
}
