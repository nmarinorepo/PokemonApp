using Pokemon.Data.Interfaces;
using Pokemon.Dtos;
using Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon.Data.Logic
{
    public class PokemonLogic : IPokemonLogic
    {
        public PokemonDto GetPokemonWeaknessesStrengths(PokemonFeatures pokemonFeatures)
        {
            PokemonDto pokemonDto = new PokemonDto();
            pokemonDto.strengths = BuildStrengthsList(pokemonFeatures.damage_relations);
            pokemonDto.weaknesses = BuildWeaknessesList(pokemonFeatures.damage_relations);

            return pokemonDto;
        }

        private List<string> BuildStrengthsList(Damage_Relations relations)
        {
            //strengths

            List<string> features = new List<string>();

            features.AddRange(relations.double_damage_to.Select(x => x.name));
            features.AddRange(relations.no_damage_from.Select(x => x.name));
            features.AddRange(relations.half_damage_from.Select(x => x.name));

            return features;
        }

        private List<string> BuildWeaknessesList(Damage_Relations relations)
        {
            //weaknesses

            List<string> features = new List<string>();

            features.AddRange(relations.no_damage_to.Select(x => x.name));
            features.AddRange(relations.half_damage_to.Select(x => x.name));
            features.AddRange(relations.double_damage_from.Select(x => x.name));

            return features;
        }
    }
}
