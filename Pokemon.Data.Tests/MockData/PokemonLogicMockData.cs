using Pokemon.Models;
using System.Collections.Generic;

namespace Pokemon.Data.Tests.MockData
{
    public class PokemonLogicMockData
    {
        public static PokemonFeatures GetPokemonFeaturesWeaknesses()
        {
            PokemonFeatures pf = new PokemonFeatures();
            pf.damage_relations = new Damage_Relations();
            pf.damage_relations.double_damage_from = new List<Damage>() { new Damage() { name = "Weakness1" } };
            pf.damage_relations.half_damage_to = new List<Damage>() { new Damage() { name = "Weakness2" } };
            pf.damage_relations.no_damage_to = new List<Damage>() { new Damage() { name = "Weakness3" } };

            return pf;
        }

        public static PokemonFeatures GetPokemonFeaturesStrengths()
        {
            PokemonFeatures pf = new PokemonFeatures();
            pf.damage_relations = new Damage_Relations();
            pf.damage_relations.double_damage_to = new List<Damage>() { new Damage() { name = "Strength1" } };
            pf.damage_relations.half_damage_from = new List<Damage>() { new Damage() { name = "Strength2" } };
            pf.damage_relations.no_damage_from = new List<Damage>() { new Damage() { name = "Strength3" } };

            return pf;
        }

        public static PokemonFeatures GetPokemonFeaturesStrengthsWeaknesses()
        {
            PokemonFeatures pf = new PokemonFeatures();
            pf.damage_relations = new Damage_Relations();
            pf.damage_relations.double_damage_to = new List<Damage>() { new Damage() { name = "Strength1" } };
            pf.damage_relations.half_damage_from = new List<Damage>() { new Damage() { name = "Strength2" } };
            pf.damage_relations.no_damage_from = new List<Damage>() { new Damage() { name = "Strength3" } };

            pf.damage_relations.double_damage_from = new List<Damage>() { new Damage() { name = "Weakness1" } };
            pf.damage_relations.half_damage_to = new List<Damage>() { new Damage() { name = "Weakness2" } };
            pf.damage_relations.no_damage_to = new List<Damage>() { new Damage() { name = "Weakness3" } };

            return pf;
        }
    }
}
