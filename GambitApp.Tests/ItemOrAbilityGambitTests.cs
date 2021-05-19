using GambitApp.Conditionals;
using GambitApp.Enums;
using Xunit;

namespace GambitApp.Tests
{
    public class ItemOrAbilityGambitTests
    {
        private readonly Character _player = new("Jimmy", 30, 10, Faction.Player);
        
        private readonly Item _potion;
        private const int PotionHpRestored = 100;

        public ItemOrAbilityGambitTests()
        {
            GameState.Entities.Add(_player);
            
            _potion = new Item
            {
                Name = "Potion",
                Effect = (user, target) => target.Heal(PotionHpRestored) 
            };
            
            var whenHealthUnder30 = new GambitCondition(Properties.Health, Comparators.IsUnder, 30);
            var usePotionOnAllyWhenHealthUnder30 = new Gambit
            {
                TargetType = TargetType.Self,
                Condition = target => whenHealthUnder30.Compose(target),
                Action = _potion
            };

            _player.AddItem(_potion);
            _player.Gambits.Add(usePotionOnAllyWhenHealthUnder30);
        }
        
        [Fact]
        public void ItemGambit_UsesItem_WhenConditionIsMet_AndHasItemInInventory()
        {
            const int startingHealth = 29;
            _player.SetHealth(startingHealth);

            _player.RunGambits();
            
            Assert.Equal(startingHealth + PotionHpRestored, _player.Health);
            Assert.Equal(0, _player.GetItemQuantityHeld(_potion));
        }
        
        [Fact]
        public void ItemGambit_DoesNotUseItem_WhenConditionIsNotMet()
        {
            const int startingHealth = 30;
            _player.SetHealth(startingHealth);

            _player.RunGambits();
            
            Assert.Equal(startingHealth, _player.Health);
            Assert.Equal(1, _player.GetItemQuantityHeld(_potion));
        }
    }
}