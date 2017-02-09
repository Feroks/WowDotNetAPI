using System.Collections.Generic;
using System.Threading.Tasks;
using WowDotNetAPI.Models.BattleNetApi.Pet;

namespace WowDotNetAPI.Repositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPets();
        Task<IEnumerable<Pet>> GetPetsAsync();

        PetAbilityDetails GetPetAbilityDetails(int id);
        Task<PetAbilityDetails> GetPetAbilityDetailsAsync(int id);

        PetSpecies GetPetSpeciesDetails(int id);
        Task<PetSpecies> GetPetSpeciesDetailsAsync(int id);

        PetStats GetPetStats(int speciesId, int level, int breedId, int qualityId);
        Task<PetStats> GetPetStatsAsync(int speciesId, int level, int breedId, int qualityId);

        IEnumerable<PetType> GetPetTypes();
        Task<IEnumerable<PetType>> GetPetTypesAsync();
    }
}
