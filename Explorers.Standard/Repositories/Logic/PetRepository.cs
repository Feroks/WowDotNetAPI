using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Pet;

namespace WowDotNetAPI.Repositories.Logic
{
    public class PetRepository :BaseRepository, IPetRepository
    {
        public PetRepository(IExplorer explorer) : base(explorer)
        {
        }

        /// <summary>
        /// Gets a list of all battle pets
        /// </summary>
        /// <returns>PetList object containing an IEnumerable of Pet objects</returns>
        public IEnumerable<Pet> GetPets()
        {
            return GetPetsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync()
        {
            return (await GetDataAsync<PetList>($@"{Host}/wow/pet/?locale={Locale}&apikey={ApiKey}")).Pets;
        }

        /// <summary>
        /// Gets details on a specific Battle Pet ability
        /// </summary>
        /// <param name="id">The id of the ability to get details on.</param>
        /// <returns>Returns PetAbilityDetails object for the ability with the given id</returns>
        public PetAbilityDetails GetPetAbilityDetails(int id)
        {
            return GetPetAbilityDetailsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<PetAbilityDetails> GetPetAbilityDetailsAsync(int id)
        {
            return await GetDataAsync<PetAbilityDetails>($@"{Host}/wow/pet/ability/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Gets details on a specific [species of] Battle Pet
        /// </summary>
        /// <param name="id">The species ID of the battle pet</param>
        /// <returns>PetSpecies object containing details for the battle pet with the given species ID</returns>
        public PetSpecies GetPetSpeciesDetails(int id)
        {
            return GetPetSpeciesDetailsAsync(id).GetAwaiter().GetResult();
        }

        public async Task<PetSpecies> GetPetSpeciesDetailsAsync(int id)
        {
            return await GetDataAsync<PetSpecies>($@"{Host}/wow/pet/species/{id}?locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// Retrieve detailed information about a given species of pet.
        /// </summary>
        /// <param name="speciesId">The pet's species ID. This can be found by querying a users' list of pets via the Character Profile API.</param>
        /// <param name="level">The pet's level. Pet levels max out at 25. If omitted the API assumes a default value of 1.</param>
        /// <param name="breedId">The pet's breed. Retrievable via the Character Profile API. If omitted the API assumes a default value of 3.</param>
        /// <param name="qualityId">The pet's quality. Retrievable via the Character Profile API. Pet quality can range from 0 to 5 (0 is poor quality and 5 is legendary). If omitted the API will assume a default value of 1.</param>
        /// <returns></returns>
        public PetStats GetPetStats(int speciesId, int level, int breedId, int qualityId)
        {
            return GetPetStatsAsync(speciesId, level, breedId, qualityId).GetAwaiter().GetResult();
        }

        public async Task<PetStats> GetPetStatsAsync(int speciesId, int level, int breedId, int qualityId)
        {
            return await GetDataAsync<PetStats>($@"{Host}/wow/pet/stats/{speciesId}?level={level}&breedId={breedId}&qualityId={qualityId}&locale={Locale}&apikey={ApiKey}");
        }

        /// <summary>
        /// The different bat pet types (including what they are strong and weak against)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PetType> GetPetTypes()
        {
            return GetPetTypesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<PetType>> GetPetTypesAsync()
        {
            var types = (await GetDataAsync<PetTypeData>($@"{Host}/wow/data/pet/types?locale={Locale}&apikey={ApiKey}")).PetTypes.ToList();
            return types.Any() ? types : null;
        }
    }
}