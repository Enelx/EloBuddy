using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo);
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (target == null || !target.IsValidTarget(Spells.Q.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Return.UseWCombo && Spells.W.IsReady() && Player.Instance.CountEnemiesInRange(Spells.Q.Range) >= 2)
            {
                Spells.W.Cast();
            }

            if (Return.UseQCombo && Spells.Q.IsReady())
            {
                Spells.Q.Cast(target);
            }
            else if (Return.UseRCombo && Spells.R.IsReady())
            {
                if (Player.Instance.Distance(target) >= Spells.E.Range)
                {
                    Spells.R.Cast(target);
                }
                else if (target.HealthPercent <= 25)
                {
                    Spells.R.Cast(target);
                }
            }
        }
    }
}