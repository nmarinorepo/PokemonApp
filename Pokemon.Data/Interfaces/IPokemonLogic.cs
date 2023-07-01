using Pokemon.Dtos;
using Pokemon.Models;

namespace Pokemon.Data.Interfaces
{
    public interface IPokemonLogic
    {
        PokemonDto GetPokemonWeaknessesStrengths(PokemonFeatures pokemonFeatures);
    }
}
