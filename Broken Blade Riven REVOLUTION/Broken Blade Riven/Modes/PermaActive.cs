using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes
{
    public static class PermaActive
    {
        public static bool ShouldBeExecuted()
        {
            return true;
        }

        public static void Execute()
        {
            if (Spells.R2.IsReady())
            {
                var target = Logic.CloseEnemies(Spells.R2.Range, Player.Instance.ServerPosition).FirstOrDefault();

                if (target != null && Spells.R2Damage(target) >= target.TotalShieldHealth() && !target.IsZombie)
                {
                    var pred = Spells.R2.GetPrediction(target);

                    Spells.R2.Cast(pred.CastPosition);
                }
            }

            if (Spells.Q.IsReady())
            {
                var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

                if (Logic.IsKillableTarget(target, Spells.Q.Range, SpellSlot.Q))
                {
                    Spells.Q.Cast(target.ServerPosition);
                }
            }
        }
    }
}