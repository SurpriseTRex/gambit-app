using System;

namespace GambitApp
{
    public class Item
    {
        public Item(string name, Action<Character> effect)
        {
            Name = name;
            Effect = effect;
        }
        
        public string Name { get; }
        public Action<Character> Effect { get; }
        
        public void Use(Character target)
        {
            Effect.Invoke(target);
        }
    }
}