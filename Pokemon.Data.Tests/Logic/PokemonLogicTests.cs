using Pokemon.Data.Logic;
using Pokemon.Data.Tests.MockData;
using Pokemon.Dtos;
using Xunit;

namespace Pokemon.Data.Tests.Logic
{
    public class PokemonLogicTests
    {
        [Fact]
        public void GetPokemonWeaknessesStrengths_ShouldReturnOnlyWeaknesses()
        {
            //Arrange

            //Act
            PokemonLogic pokemonLogic = new PokemonLogic();
            PokemonDto pokemonDto = pokemonLogic.GetPokemonWeaknessesStrengths(PokemonLogicMockData.GetPokemonFeaturesWeaknesses());

            //Assert
            Assert.Contains("Weakness1", pokemonDto.weaknesses);
            Assert.Contains("Weakness2", pokemonDto.weaknesses);
            Assert.Contains("Weakness3", pokemonDto.weaknesses);
            Assert.True(pokemonDto.weaknesses.Count.Equals(3));
            Assert.True(pokemonDto.strengths.Count.Equals(0));
        }

        [Fact]
        public void GetPokemonWeaknessesStrengths_ShouldReturnOnlyStrengths()
        {
            //Arrange

            //Act
            PokemonLogic pokemonLogic = new PokemonLogic();
            PokemonDto pokemonDto = pokemonLogic.GetPokemonWeaknessesStrengths(PokemonLogicMockData.GetPokemonFeaturesStrengths());

            //Assert
            Assert.Contains("Strength1", pokemonDto.strengths);
            Assert.Contains("Strength2", pokemonDto.strengths);
            Assert.Contains("Strength3", pokemonDto.strengths);
            Assert.True(pokemonDto.strengths.Count.Equals(3));
            Assert.True(pokemonDto.weaknesses.Count.Equals(0));
        }

        [Fact]
        public void GetPokemonWeaknessesStrengths_ShouldReturnStrengthsWeaknesses()
        {
            //Arrange

            //Act
            PokemonLogic pokemonLogic = new PokemonLogic();
            PokemonDto pokemonDto = pokemonLogic.GetPokemonWeaknessesStrengths(PokemonLogicMockData.GetPokemonFeaturesStrengthsWeaknesses());

            //Assert
            Assert.Contains("Strength1", pokemonDto.strengths);
            Assert.Contains("Strength2", pokemonDto.strengths);
            Assert.Contains("Strength3", pokemonDto.strengths);
            Assert.Contains("Weakness1", pokemonDto.weaknesses);
            Assert.Contains("Weakness2", pokemonDto.weaknesses);
            Assert.Contains("Weakness3", pokemonDto.weaknesses);

            Assert.True(pokemonDto.strengths.Count.Equals(3));
            Assert.True(pokemonDto.weaknesses.Count.Equals(3));
        }
    }
}
