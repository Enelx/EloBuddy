using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class Jungle
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbJungleClear;
        }

        public static void Execute()
        {
            var creeps =
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, 600)
                    .OrderByDescending(a => a.MaxHealth)
                    .FirstOrDefault();

            if (creeps != null)
            {
                if (Spells.Q.IsReady() && Return.UseQJungle)
                {
                    if (creeps.IsValidTarget(Spells.Q.Range))
                        Spells.Q.Cast(creeps);
                }

                if (Spells.W.IsReady() && Return.UseWJungle)
                {
                    if (creeps.IsValidTarget(Spells.W.Range))
                        Spells.W.Cast(creeps);
                }

                if (Spells.E.IsReady() && Return.UseEJungle)
                {
                    if (creeps.IsValidTarget(Spells.E.Range))
                        Spells.E.Cast(creeps.ServerPosition);
                }
            }
        }
    }
}