using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pokemon.Data.Interfaces;
using Pokemon.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ILogger<PokemonRepository> _log;
        private readonly IConfiguration _config;
        public PokemonRepository(ILogger<PokemonRepository> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }


        async Task<string> CallPokemonAPIAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                string result = string.Empty;
                if (response.IsSuccessStatusCode)
                {
                    result = await content.ReadAsStringAsync();
                }                 
                return result;
            }
        }

        string GetPokemonByName(string pokeAPIRequest)
        {
            return CallPokemonAPIAsync(pokeAPIRequest).Result;
        }

        string GetPokemonFeaturesByType(string pokeAPIRequest)
        {
            return CallPokemonAPIAsync(pokeAPIRequest).Result;
        }


        public PokemonFeatures GetPokemonFeaturesByName(string pokemonName)
        {
            try
            {
                string pokeAPIBaseURL = this._config.GetSection("PokeAPIBaseURL").Value;
                string pokeAPIRequest = string.Format("{0}pokemon/{1}", pokeAPIBaseURL, pokemonName);


                string pokemonByName = GetPokemonByName(pokeAPIRequest);

                if (!string.IsNullOrEmpty(pokemonByName))
                {
                    Models.Pokemon pokemon = JsonConvert.DeserializeObject<Models.Pokemon>(pokemonByName);
                    string typeUrl = pokemon.types[0].type.url;

                    string pokemonFeaturesByType = GetPokemonFeaturesByType(typeUrl);
                    PokemonFeatures pokemonFeatures = JsonConvert.DeserializeObject<PokemonFeatures>(pokemonFeaturesByType);
                    return pokemonFeatures;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _log.LogError("GetPokemonFeaturesByName - Error {0} - StackTrace {1}", ex.Message, ex.StackTrace);
                throw new Exception("An error has occurred. Please contact technical support");
            }
        }

    }
}
