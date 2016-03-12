using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Jungle
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.JungleClear);
        }

        public static void Execute()
        {
            var monster =
                Logic.Monsters(Spells.Q.Range, Player.Instance.ServerPosition)
                    .FirstOrDefault();

            if (monster == null || !monster.IsValidTarget()) return;

            if (Return.UseQJungle && Spells.Q.IsReady())
            {
                Spells.Q.Cast(monster);
            }
        }
    }
}