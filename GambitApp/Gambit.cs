using System;

namespace GambitApp
{
    public class Gambit
    {
        public Hostility Hostility { get; }
        public Func<Character, Character, bool> Condition { get; set; }
        public Action<Character, Character> Action { get; set; }

        public bool IsConditionMet(Character actor, Character target)
        {
            return Condition.Invoke(actor, target);
        }

        public void Trigger(Character actor, Character target)
        {
            Action.Invoke(actor, target);
        }
    }
}