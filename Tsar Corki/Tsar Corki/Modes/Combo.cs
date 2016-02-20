using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Tsar_Corki.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbCombo;
        }

        public static void Execute()
        {
            if (Spells.Q.IsReady() && Return.UseQCombo)
            {
                var t = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);

                if (t != null)
                {
                    Spells.Q.Cast(t.ServerPosition);
                }
            }

            if (Spells.R.IsReady() && Return.UseRCombo && Spells.R.Handle.Ammo > 0)
            {
                var t = TargetSelector.GetTarget(Spells.R.Range, DamageType.Magical);

                if (t != null)
                {
                    Spells.R.Cast(t.ServerPosition);
                }
            }

            if (Spells.E.IsReady() && Return.UseECombo)
            {
                var t = TargetSelector.GetTarget(Spells.E.Range, DamageType.Physical);

                if (t != null && Player.Instance.IsFacing(t))
                    Spells.E.Cast();
            }
        }
    }
}
