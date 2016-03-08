using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Clear
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.LaneClear);
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.ClearEnergyMin) return;

            var minion =
                Logic.Minions(EntityManager.UnitTeam.Enemy, Spells.Q.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            if (minion == null || !minion.IsValidTarget(Spells.Q.Range)) return;

            if (Return.UseQClear && Spells.Q.IsReady())
            {
                Spells.Q.Cast(minion);
            }

            if (Return.UseEClear && Spells.E.IsReady() && minion.IsValidTarget(Spells.E.Range))
            {
                Spells.E.Cast();
            }
        }
    }
}