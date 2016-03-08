using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Lasthit
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.LastHit);
        }

        public static void Execute()
        {
            var qminion =
                Logic.Minions(EntityManager.UnitTeam.Enemy, Spells.Q.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            var eminion =
                Logic.Minions(EntityManager.UnitTeam.Enemy, Spells.E.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            var qiskillable = Logic.IsKillableMinion(qminion, Spells.Q.Range, SpellSlot.Q);
            var eiskillable = Logic.IsKillableMinion(eminion, Spells.E.Range, SpellSlot.E);

            if (qminion != null && !Player.Instance.IsInAutoAttackRange(qminion))
            {
                if (Return.UseQLast && Spells.Q.IsReady() && qiskillable)
                {
                    Spells.Q.Cast(qminion);
                }
            }

            if (eminion != null)
            {
                if (Return.UseELast && Spells.E.IsReady() && eiskillable)
                {
                    Spells.E.Cast();
                }
            }
        }
    }
}