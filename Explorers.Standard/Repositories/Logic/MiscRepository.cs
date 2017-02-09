using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi;
using WowDotNetAPI.Models.BattleNetApi.Mount;

namespace WowDotNetAPI.Repositories.Logic
{
    public class MiscRepository : BaseRepository, IMiscRepository
    {
        public MiscRepository(IExplorer explorer) : base(explorer)
        {
        }

        public IEnumerable<Mount> GetMounts()
        {
            return GetMountsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Mount>> GetMountsAsync()
        {
            return (await GetDataAsync<Mounts>($@"{Host}/wow/mount/?locale={Locale}&apikey={ApiKey}")).MountList;
        }

        /// <summary>
        /// Retrieve metadata for a given quest.
        /// </summary>
        /// <param name="questId">The ID of the desired quest.</param>
        /// <returns></returns>
        public Quest GetQuestData(int questId)
        {
            return GetQuestDataAsync(questId).GetAwaiter().GetResult();
        }

        public async Task<Quest> GetQuestDataAsync(int questId)
        {
            return await GetDataAsync<Quest>($@"{Host}/wow/quest/{questId}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// The recipe API provides basic recipe information.
        /// </summary>
        /// <param name="recipeId">Unique ID for the desired recipe.</param>
        /// <returns></returns>
        public Recipe GetRecipeData(int recipeId)
        {
            return GetRecipeDataAsync(recipeId).GetAwaiter().GetResult();
        }

        public async Task<Recipe> GetRecipeDataAsync(int recipeId)
        {
            return await GetDataAsync<Recipe>($@"{Host}/wow/recipe/{recipeId}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// The spell API provides some information about spells.
        /// </summary>
        /// <param name="spellId">Unique ID of the desired spell.</param>
        /// <returns></returns>
        public Spell GetSpellData(int spellId)
        {
            return GetSpellDataAsync(spellId).GetAwaiter().GetResult();
        }

        public async Task<Spell> GetSpellDataAsync(int spellId)
        {
            return await GetDataAsync<Spell>($@"{Host}/wow/spell/{spellId}?locale={Locale}&apikey={ApiKey}");
        }
    }
}
