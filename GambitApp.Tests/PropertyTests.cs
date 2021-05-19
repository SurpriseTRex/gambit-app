using GambitApp.Conditionals;
using GambitApp.Enums;
using Xunit;

namespace GambitApp.Tests
{
    public class PropertyTests
    {
        private readonly Character _character;

        public PropertyTests()
        {
            _character = new Character("Test", 1, 2, Faction.Player);
        }
        
        [Fact]
        public void EnsureUniqueValues()
        {
            Assert.NotEqual(_character.Health, _character.Mana);
            // add other fields here as we add them, to ensure that we never
            // accidentally compare two equal but unrelated character property values.
        }

        [Fact]
        public void Health()
        {
            var result = Properties.Health.Invoke(_character);
            
            Assert.Equal(_character.Health, result);
        }
        
        [Fact]
        public void Mana()
        {
            var result = Properties.Mana.Invoke(_character);
            
            Assert.Equal(_character.Mana, result);
        }
    }
}