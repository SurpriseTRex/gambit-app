using System;

namespace GambitApp
{
    public class Gambit
    {
        public Gambit(Faction faction, Func<Character, Character, bool> condition, Action<Character, Character> action)
        {
            Faction = faction;
            Condition = condition;
            Action = action;
        }

        public Faction Faction { get; }
        public Func<Character, Character, bool> Condition { get; init; }
        public Action<Character, Character> Action { get; init; }

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