using System;

namespace GambitApp
{
    public class Item
    {
        public string Name { get; set; }
        public Action<Character, Character> Effect { get; set; }
        
        public void Use(Character user, Character target)
        {
            Effect.Invoke(user, target);
            Console.WriteLine($"{user.Name} used [{Name}] on {target.Name}");
        }
    }
}