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
            return Return.Activemode(Orbwalker.ActiveModes.LastHit);
        }

        public static void Execute()
        {
            var minion =
                Logic.Minions(EntityManager.UnitTeam.Enemy, Spells.Q.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            var isKillable = Logic.IsKillableMinion(minion, Spells.Q.Range, SpellSlot.Q);

            if (minion != null && !Player.Instance.IsInAutoAttackRange(minion))
            {
                if (Return.UseQLast && Spells.Q.IsReady() && isKillable)
                    Spells.Q.Cast(minion);
            }
        }
    }
}