using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class Harass
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Harass);
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.HarassManaMin) return;

            var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (target != null & target.IsValidTarget(Spells.Q.Range))
            {
                if (Return.UseQHarass && Spells.Q.IsReady())
                    Spells.Q.Cast(target);
            }
        }
    }
}