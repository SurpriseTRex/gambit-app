using System;

namespace GambitApp
{
    public static class Effects
    {
        public static Action<Character, Character>
            
            // This should probably be user.BaseDamage, or something.
            // Can even do Formulas class with the funcs for this.
            // e.g.
            // DamageFormula = (actor, target) => ((actor str * weapon dmg) - (target defense)) / resistance

            Attack = (user, target) => target.Harm(30), 

            Heal = (user, target) => target.Heal(30),

            VampStrike = (user, target) =>
            {
                target.Harm(30);
                user.Heal(15);
            };
        
        // How to do buffs? Need to:
        // - add them to a list of statuses
        // - take their effects into account somehow
        // - handle expiry/dispel
    }
}