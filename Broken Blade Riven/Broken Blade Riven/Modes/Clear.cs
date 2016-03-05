using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes
{
    public static class Clear
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.LaneClear);
        }

        public static void Execute()
        {
            var minion =
                Logic.Minions(EntityManager.UnitTeam.Enemy, Spells.E.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            if (minion == null && !minion.IsValidTarget(Spells.E.Range)) return;

            if (Return.UseQClear && Spells.Q.IsReady() && minion.IsValidTarget(Spells.Q.Range))
            {
                Spells.Q.Cast(minion.ServerPosition);
                minion.Autoattack();
                Spells.Q.Cast(minion.ServerPosition);
                minion.Autoattack();
                Spells.Q.Cast(minion.ServerPosition);
            }

            if (Return.UseEClear && Spells.E.IsReady() && !Player.Instance.IsInAutoAttackRange(minion))
            {
                Spells.E.Cast(minion.ServerPosition);
            }

            if (Return.UseWClear && Spells.W.IsReady() &&
                minion.Health <= Player.Instance.GetSpellDamage(minion, SpellSlot.W))
            {
                Spells.W.Cast();
            }
        }
    }
}