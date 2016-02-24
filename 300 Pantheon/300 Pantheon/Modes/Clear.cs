using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class Clear
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbLaneClear;
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.ClearManaMin) return;

            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                    Player.Instance.ServerPosition, Spells.Q.Range).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

            if (minions != null)
            {
                if (Return.UseQJungle && Spells.Q.IsReady())
                    Spells.Q.Cast(minions);

                if (Return.UseWJungle && Spells.W.IsReady())
                    Spells.W.Cast(minions);

                if (Return.UseEJungle && Spells.E.IsReady())
                    Spells.E.Cast(minions.ServerPosition);
            }
        }
    }
}