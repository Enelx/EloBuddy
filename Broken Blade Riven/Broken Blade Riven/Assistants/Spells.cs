using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Broken_Blade_Riven.Assistants
{
    public static class Spells
    {
        // Define and Initialize Spells
        public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 260, SkillShotType.Linear);
        public static Spell.Active W = new Spell.Active(SpellSlot.W, 125);
        public static Spell.Skillshot E = new Spell.Skillshot(SpellSlot.E, 325, SkillShotType.Linear);
        public static Spell.Active R1 = new Spell.Active(SpellSlot.R);
        public static Spell.Skillshot R2 = new Spell.Skillshot(SpellSlot.R, 900, SkillShotType.Cone, 250, 1600, 225);

        public static Spell.Skillshot Flash;

        public static void Initialize()
        {
            var slot = Player.Instance.GetSpellSlotFromName("summonerflash");

            if (slot != SpellSlot.Unknown)
            {
                Flash = new Spell.Skillshot(slot, 425, SkillShotType.Linear);
            }
        }
    }
}