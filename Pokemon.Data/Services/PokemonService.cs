using Microsoft.Extensions.Logging;
using Pokemon.Data.Interfaces;
using Pokemon.Dtos;
using Pokemon.Models;
using System;

namespace Pokemon.Data.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokemonLogic _pokemonLogic;
        private readonly ILogger<PokemonService> _log;

        public PokemonService(IPokemonRepository pokemonRepository, IPokemonLogic pokemonLogic, ILogger<PokemonService> log)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonLogic = pokemonLogic;
            _log = log;
        }


        public void Run()
        {
            Console.Write("Please enter a Pokémon's name: ");
            string pokemonName = Console.ReadLine();

            if (!string.IsNullOrEmpty(pokemonName.Trim()))
            {
                PokemonFeatures pokemonFeatures;
                try
                {
                    pokemonFeatures = _pokemonRepository.GetPokemonFeaturesByName(pokemonName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                if (pokemonFeatures != null)
                {
                    PokemonDto pokemonDto = _pokemonLogic.GetPokemonWeaknessesStrengths(pokemonFeatures);
                    ShowStrengthsWeaknesses(pokemonDto);
                }
                else
                {
                    _log.LogInformation($"No results found with name: {pokemonName}");
                    Console.WriteLine($"No results found with name: {pokemonName}");
                }
            }
            else
            {
                _log.LogInformation("Pokémon's name is mandatory");
                Console.WriteLine("Pokémon's name is mandatory");
            }
        }

        private void ShowStrengthsWeaknesses(PokemonDto pokemonDto)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Strengths against types:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            foreach (var item in pokemonDto.strengths)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Weaknesses against types:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            foreach (var item in pokemonDto.weaknesses)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }
    }
}
