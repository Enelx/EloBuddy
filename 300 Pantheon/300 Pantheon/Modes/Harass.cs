using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace _300_Pantheon.Modes
{
    public static class Harass
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbHarass;
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.HarassManaMin) return;

            var t = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);

            if (t != null)
            {
                if (Return.UseQHarass && Spells.Q.IsReady())
                    Spells.Q.Cast(t);
            }
        }
    }
}
