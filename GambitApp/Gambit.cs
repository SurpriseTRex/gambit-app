using System;

namespace GambitApp
{
    public class Gambit
    {
        public Func<Character, Character, bool> Condition { get; set; }
        public Action<Character, Character> Action { get; set; }
    }
}