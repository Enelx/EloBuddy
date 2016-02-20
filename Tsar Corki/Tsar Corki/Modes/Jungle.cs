using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Tsar_Corki.Modes
{
    public static class Jungle
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbJungleClear;
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.JungleManaMin)
                return;

            var creep = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, Spells.Q.Range).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

            if (creep != null)
            {
                if (Spells.Q.IsReady() && Return.UseQJungle)
                    Spells.Q.Cast(creep.ServerPosition);

                if (Spells.R.IsReady() && Return.UseRJungle)
                    Spells.R.Cast(creep.ServerPosition);
            }
        }
    }
}
