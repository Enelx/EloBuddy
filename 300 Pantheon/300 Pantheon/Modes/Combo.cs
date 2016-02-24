using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace _300_Pantheon.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbCombo;
        }

        public static void Execute()
        {
            var t = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);

            if (t != null)
            {
                if (Return.UseAgressiveItems)
                    Items.CastItems(t);

                if (Return.UseQCombo && Spells.Q.IsReady())
                    Spells.Q.Cast(t);

                if (Return.UseWCombo && Spells.W.IsReady())
                    Spells.W.Cast(t);

                if (Return.UseECombo && Spells.E.IsReady())
                    Spells.E.Cast(t.ServerPosition);
            }
        }
    }
}
