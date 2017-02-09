using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Challenge;

namespace WowDotNetAPI.Repositories
{
    public interface IChallengeRepository
    {
        Challenges GetChallenges(string realm);
        Task<Challenges> GetChallengesAsync(string realm);
       
    }
}
