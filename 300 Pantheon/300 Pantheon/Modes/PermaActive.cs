using System.Linq;
using EloBuddy;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class PermaActive
    {
        public static bool ShouldBeExecuted()
        {
            return true;
        }

        public static void Execute()
        {
            if (Return.UseQKs && Spells.Q.IsReady())
            {
                var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

                if (Logic.IsKillableTarget(target, Spells.Q.Range, SpellSlot.Q))
                {
                    Spells.Q.Cast(target);
                }
            }

            if (Return.UseWKs && Spells.W.IsReady())
            {
                var target = Logic.CloseEnemies(Spells.W.Range, Player.Instance.ServerPosition).FirstOrDefault();

                if (Logic.IsKillableTarget(target, Spells.W.Range, SpellSlot.W))
                {
                    Spells.W.Cast(target);
                }
            }
        }
    }
}