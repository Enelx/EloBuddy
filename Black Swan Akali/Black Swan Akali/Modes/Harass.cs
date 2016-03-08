using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Harass
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Harass);
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (target == null || !target.IsValidTarget(Spells.Q.Range)) return;

            if (Return.UseQHarass && Spells.Q.IsReady())
            {
                Spells.Q.Cast(target);
            }
        }
    }
}