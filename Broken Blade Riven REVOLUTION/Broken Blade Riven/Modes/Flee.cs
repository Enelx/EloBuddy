using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes
{
    public static class Flee
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Flee);
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.W.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (Spells.W.IsReady() && target.IsValidTarget(Spells.W.Range))
            {
                Spells.W.Cast();
            }
            else if (Spells.E.IsReady())
            {
                var curSpot = Player.Instance.Position.Extend(Game.CursorPos, Spells.E.Range);

                Spells.E.Cast(curSpot.To3D());
            }
            else if (Spells.Q.IsReady())
            {
                var curSpot = Player.Instance.Position.Extend(Game.CursorPos, Spells.Q.Range);

                Spells.Q.Cast(curSpot.To3D());
            }
        }
    }
}