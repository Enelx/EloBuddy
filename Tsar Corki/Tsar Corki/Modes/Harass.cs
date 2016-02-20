using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Tsar_Corki.Modes
{
    public static class Harass
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbHarass;
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.HarassManaMin)
                return;

            if (Spells.Q.IsReady() && Return.UseQHarass)
            {
                var t = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Magical);

                if (t != null)
                {
                    Spells.Q.Cast(t.ServerPosition);
                }
            }

            if (Spells.E.IsReady() && Return.UseEHarass)
            {
                var t = TargetSelector.GetTarget(Spells.E.Range, DamageType.Physical);

                if (t != null && Player.Instance.IsFacing(t))
                    Spells.E.Cast();
            }

            if (Spells.R.IsReady() && Return.UseRHarass && Spells.R.Handle.Ammo > Return.HarassRSave)
            {
                var t = TargetSelector.GetTarget(Spells.R.Range, DamageType.Magical);

                if (t != null)
                {
                    Spells.R.Cast(t.ServerPosition);
                }
            }
        }
    }
}
