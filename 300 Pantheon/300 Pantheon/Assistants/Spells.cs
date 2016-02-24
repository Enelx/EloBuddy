using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace _300_Pantheon
{
    public static class Spells
    {
        // Define and Initialize Spells
        public static Spell.Targeted Q = new Spell.Targeted(SpellSlot.Q, 600);
        public static Spell.Targeted W = new Spell.Targeted(SpellSlot.W, 600);
        public static Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 600, SkillShotType.Cone, 250, 2000, 15 * 2 * (int)Math.PI / 180);
    }
}
