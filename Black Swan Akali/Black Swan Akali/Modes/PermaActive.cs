using System.Linq;
using Black_Swan_Akali.Assistants;
using EloBuddy;

namespace Black_Swan_Akali.Modes
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

            if (Return.UseRKs && Spells.R.IsReady())
            {
                var target = Logic.CloseEnemies(Spells.R.Range, Player.Instance.ServerPosition).FirstOrDefault();

                if (Logic.IsKillableTarget(target, Spells.R.Range, SpellSlot.R))
                {
                    Spells.R.Cast(target);
                }
            }
        }
    }
}