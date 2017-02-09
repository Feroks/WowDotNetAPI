using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi;
using WowDotNetAPI.Models.BattleNetApi.Mount;

namespace WowDotNetAPI.Repositories
{
    public interface IMiscRepository
    {
        IEnumerable<Mount> GetMounts();
        Task<IEnumerable<Mount>> GetMountsAsync();

        Quest GetQuestData(int questId);
        Task<Quest> GetQuestDataAsync(int questId);

        Recipe GetRecipeData(int recipeId);
        Task<Recipe> GetRecipeDataAsync(int recipeId);

        Spell GetSpellData(int spellId);
        Task<Spell> GetSpellDataAsync(int spellId);
    }
}
