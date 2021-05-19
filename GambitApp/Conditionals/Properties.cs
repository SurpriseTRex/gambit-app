using System;

namespace GambitApp.Conditionals
{
    public static class Properties
    {
        public static Func<Character, int>
            Health = c => c.Health,
            Mana = c => c.Mana;
    }
}