using Pokemon.Models;

namespace Pokemon.Data.Interfaces
{
    public interface IPokemonRepository
    {
        PokemonFeatures GetPokemonFeaturesByName(string pokemonName);
    }
}