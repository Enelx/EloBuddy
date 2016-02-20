using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Tsar_Corki
{
    public static class Spells
    {
        // Define and Initialize Spells
        public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 825, SkillShotType.Circular, 350, 1000, 150) { MinimumHitChance = HitChance.High };
        public static Spell.Active W = new Spell.Active(SpellSlot.W);
        public static Spell.Active E = new Spell.Active(SpellSlot.E, 500);
        public static Spell.Skillshot R = new Spell.Skillshot(SpellSlot.R, 1225, SkillShotType.Linear, 250, 1950, 40) { AllowedCollisionCount = 0, MinimumHitChance = HitChance.High };
    }
}
