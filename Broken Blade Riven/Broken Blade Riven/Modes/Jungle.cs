using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Modes.Combo
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

            if (monster == null && !monster.IsValidTarget(Spells.E.Range)) return;

            if (Return.UseEJungle && Spells.E.IsReady())
            {
                Spells.E.Cast(monster.ServerPosition);
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Return.UseWJungle && Spells.W.IsReady())
            {
                Spells.W.Cast();
            }
            else if (Return.UseQJungle && Spells.Q.IsReady())
            {
                Spells.Q.Cast(monster.ServerPosition);
                monster.Autoattack();
                Spells.Q.Cast(monster.ServerPosition);
                monster.Autoattack();
                Spells.Q.Cast(monster.ServerPosition);
            }
        }
    }
}