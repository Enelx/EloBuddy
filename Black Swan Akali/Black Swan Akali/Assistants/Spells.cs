using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Assistants
{
    public static class Spells
    {
        // Define and Initialize Spells
        public static Spell.Targeted Q = new Spell.Targeted(SpellSlot.Q, 600);
        public static Spell.Active W = new Spell.Active(SpellSlot.W, 700);
        public static Spell.Active E = new Spell.Active(SpellSlot.E, 325);
        public static Spell.Targeted R = new Spell.Targeted(SpellSlot.R, 700);
    }
}