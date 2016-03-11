using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes
{
    public static class Jungle
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.JungleClear);
        }

        public static void Execute()
        {
            var monster = Logic.Monsters(Spells.E.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (monster == null || !monster.IsValidTarget()) return;

            if (Spells.E.IsReady() && Return.UseEJungle)
            {
                Spells.E.Cast(monster.ServerPosition);
            }
            else if (Spells.W.IsReady() && Return.UseWJungle && monster.IsValidTarget(Spells.W.Range))
            {
                Spells.W.Cast();
            }
        }
    }
}