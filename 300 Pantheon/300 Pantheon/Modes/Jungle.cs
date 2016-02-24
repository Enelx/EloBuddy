using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

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
            var Creeps = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, 600).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

            if (Creeps != null)
            {
                if (Spells.Q.IsReady() && Return.UseQJungle)
                {
                    if (Creeps.IsValidTarget(Spells.Q.Range))
                        Spells.Q.Cast(Creeps);
                }

                if (Spells.W.IsReady() && Return.UseWJungle)
                {
                    if (Creeps.IsValidTarget(Spells.W.Range))
                        Spells.W.Cast(Creeps);
                }

                if (Spells.E.IsReady() && Return.UseEJungle)
                {
                    if (Creeps.IsValidTarget(Spells.E.Range))
                        Spells.E.Cast(Creeps.ServerPosition);
                }
            }
        }
    }
}
