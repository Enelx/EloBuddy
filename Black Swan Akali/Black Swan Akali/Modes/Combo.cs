using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Black_Swan_Akali.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbCombo;
        }

        public static void Execute()
        {
            // Use Items

            var t = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);

            if (t != null && Return.UseItemBilge && Items.bilge.IsOwned() && Items.bilge.IsReady() && Items.bilge.IsInRange(t))
                Items.bilge.Cast(t);

            if (t != null && Return.UseItemBotrk && Items.Botrk.IsOwned() && Items.Botrk.IsReady() && Items.Botrk.IsInRange(t))
                Items.Botrk.Cast(t);

            if (t != null && Return.UseItemHextech && Items.Hextech.IsOwned() && Items.Hextech.IsReady() && Items.Hextech.IsInRange(t))
                Items.Hextech.Cast(t);

            // Use Spells

            if (Spells.Q.IsReady() && Return.UseQCombo)
            {
                if (t != null)
                    Spells.Q.Cast(t);
            }

            if (Spells.R.IsReady() && Return.UseRCombo)
            {
                var Rt = TargetSelector.GetTarget(Spells.R.Range, DamageType.Magical);

                if (Rt != null)
                    Spells.R.Cast(Rt);
            }

            if (Spells.W.IsReady() && Return.UseWCombo)
            {
                if (t != null && Player.Instance.CountEnemiesInRange(Spells.Q.Range) >= 2)
                    Spells.W.Cast();
            }
        }
    }
}
