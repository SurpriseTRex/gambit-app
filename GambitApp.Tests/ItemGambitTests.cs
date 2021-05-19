using GambitApp.Conditionals;
using GambitApp.Enums;
using Xunit;

namespace GambitApp.Tests
{
    public class ItemGambitTests
    {
        private readonly Character _player = new("Jimmy", 111, 10, Faction.Player);
        private const int PotionHpRestored = 100;

        public ItemGambitTests()
        {
            GameState.Entities.Add(_player);
            
            var potion = new Item
            {
                Name = "Potion I",
                Effect = (user, target) => target.Health += PotionHpRestored 
            };
            
            var whenHealthUnder30 = new GambitCondition(Properties.Health, Comparators.IsUnder, 30);
            var usePotionOnAllyWhenHealthUnder30 = new ItemGambit
            {
                TargetType = TargetType.Self,
                Condition = target => whenHealthUnder30.Compose(target),
                Item = potion
            };
            
            _player.Gambits.Add(usePotionOnAllyWhenHealthUnder30);
        }
        
        [Fact]
        public void ItemGambit_UsesItem_WhenConditionIsMet()
        {
            const int startingHealth = 29;
            _player.Health = startingHealth;

            _player.RunGambits();
            
            Assert.Equal(startingHealth + PotionHpRestored, _player.Health);
        }
        
        [Fact]
        public void ItemGambit_DoesNotUseItem_WhenConditionIsNotMet()
        {
            const int startingHealth = 30;
            _player.Health = startingHealth;

            _player.RunGambits();
            
            Assert.Equal(startingHealth, _player.Health);
        }
    }
}