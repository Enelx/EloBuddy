using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class PermaActive
    {
        public static bool ShouldBeExecuted()
        {
            return true;
        }

        public static void Execute()
        {
            if (Return.UseQKs && Spells.Q.IsReady())
            {
                var target =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        x =>
                            x.IsValidTarget(Spells.Q.Range) && !x.HasBuffOfType(BuffType.Invulnerability) &&
                            x.TotalShieldHealth() + 5 <= Player.Instance.GetSpellDamage(x, SpellSlot.Q));
                {
                    Spells.Q.Cast(target);
                }
            }

            if (Return.UseWKs && Spells.W.IsReady())
            {
                var target =
                    EntityManager.Heroes.Enemies.FirstOrDefault(
                        x => x.IsValidTarget(Spells.W.Range) && !x.HasBuffOfType(BuffType.Invulnerability) &&
                             x.TotalShield() <= Player.Instance.GetSpellDamage(x, SpellSlot.W));
                {
                    Spells.W.Cast(target);
                }
            }

        }
    }
}