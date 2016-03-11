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

        public static Spell.Skillshot R2 = new Spell.Skillshot(SpellSlot.R, 900, SkillShotType.Cone, 250, 1600, 20)
        {
            AllowedCollisionCount = int.MaxValue
        };

        public static Spell.Skillshot Flash;

        public static float R2Damage(AIHeroClient target, double healthMod = 0)
        {
            if (!Player.Instance.HasBuff("rivenwindslashready") || target == null || !target.IsValidTarget(R2.Range))
            {
                return 0;
            }

            var hpPercent = (target.Health - healthMod > 0 ? 1 : target.TotalShieldHealth() - healthMod)/
                            target.MaxHealth;

            return
                (float)
                    ((new double[] {80, 120, 160}[R1.Level - 1] + 0.6*Player.Instance.FlatPhysicalDamageMod)*
                     (hpPercent < 25 ? 3 : (100 - hpPercent)*2.67/100 + 1));
        }

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