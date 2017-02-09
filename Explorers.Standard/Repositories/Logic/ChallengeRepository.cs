using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Challenge;

namespace WowDotNetAPI.Repositories.Logic
{
    public class ChallengeRepository :BaseRepository, IChallengeRepository
    {
        public ChallengeRepository(IExplorer explorer) : base(explorer)
        {
        }

        /// <summary>
        /// The data in this request has data for all 9 challenge mode maps (currently). The map field includes the current medal times for each dungeon. Inside each ladder we provide data about each character that was part of each run. The character data includes the current cached spec of the character while the member field includes the spec of the character during the challenge mode run.
        /// </summary>
        /// <param name="realm">The realm being requested.</param>
        /// <returns></returns>
        public Challenges GetChallenges(string realm)
        {
            return GetChallengesAsync(realm).GetAwaiter().GetResult();
        }

        public async Task<Challenges> GetChallengesAsync(string realm)
        {
            return await GetDataAsync<Challenges>($@"{Host}/wow/challenge/{realm}?locale={Locale}&apikey={ApiKey}");
        }
    }
}