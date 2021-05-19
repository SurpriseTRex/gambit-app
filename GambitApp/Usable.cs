using System;

namespace GambitApp
{
    public class Item : IAction
    {
        public string Name { get; set; }
        public Action<Character, Character> Effect { get; set; }
        
        public void Use(Character user, Character target)
        {
            Effect.Invoke(user, target);
            Console.WriteLine($"{user.Name} used Item [{Name}] on {target.Name}");
        }
    }

    public class Ability : IAction
    {
        public string Name { get; set; }
        public Action<Character, Character> Effect { get; set; }
        
        public int ManaCost { get; set; }

        public void Use(Character user, Character target)
        {
            Effect.Invoke(user, target);
            Console.WriteLine($"{user.Name} used Ability [{Name}] on {target.Name}");
        }
    }
    
    public interface IAction
    {
        string Name { get; set; }
        Action<Character, Character> Effect { get; set; }
        void Use(Character user, Character target);
    }
}