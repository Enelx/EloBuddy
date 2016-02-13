using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Predator_Rengar
{
    public static class Spells
    {
        // Define and Initialize Spells
        public static Spell.Active Q = new Spell.Active(SpellSlot.Q);
        public static Spell.Active W = new Spell.Active(SpellSlot.W, 500);
        public static Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 1000, SkillShotType.Linear, 125, 1500, 70);
        public static Spell.Active R = new Spell.Active(SpellSlot.R);
    }
}
