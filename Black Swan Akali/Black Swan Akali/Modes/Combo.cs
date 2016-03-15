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
            var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);

            if (target == null || !target.IsValidTarget()) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Return.UseQCombo && Spells.Q.IsReady())
            {
                Spells.Q.Cast(target);
            }
            
            if (Return.UseRCombo && Spells.R.IsReady() && !Player.Instance.IsInRange(target, Spells.E.Range))
            {
                Spells.R.Cast(target);
            }

            if (Return.UseWCombo && Spells.W.IsReady() && Player.Instance.CountEnemiesInRange(Spells.Q.Range) >= 2)
            {
                Spells.W.Cast();
            }
        }
    }
}