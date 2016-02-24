using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class Lasthit
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbLastHit;
        }

        public static void Execute()
        {
            var qMinions =
                EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                    Player.Instance.ServerPosition, Spells.Q.Range)
                    .OrderByDescending(a => a.MaxHealth)
                    .FirstOrDefault(
                        a =>
                            a.IsValidTarget(Spells.Q.Range) && a.Health < Player.Instance.GetSpellDamage(a, SpellSlot.Q));

            if (Spells.Q.IsReady() && Return.UseQLast)
            {
                if (qMinions != null && !Player.Instance.IsInAutoAttackRange(qMinions))
                    Spells.Q.Cast(qMinions);
            }
        }
    }
}