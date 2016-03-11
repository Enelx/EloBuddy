using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo);
        }

        public static void Execute()
        {
            // out of aa -> cast w
            var target = TargetSelector.GetTarget(Spells.E.Range + Player.Instance.AttackRange, DamageType.Physical);

            if (target == null || !target.IsValidTarget()) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady() && Return.UseForceR1 && !Player.Instance.HasBuff("rivenwindslashready"))
            {
                Spells.R1.Cast();
            }
            else if (Spells.Flash.IsReady() && Return.UseComboFlash)
            {
                Spells.Flash.Cast(target.ServerPosition);
            }
            else if (Spells.W.IsReady() && target.IsValidTarget(Spells.W.Range))
            {
                Spells.W.Cast();
            }
        }
    }
}