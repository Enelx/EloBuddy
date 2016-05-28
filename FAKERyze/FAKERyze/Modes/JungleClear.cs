using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace FAKERyze.Modes
{
    internal class JungleClear
    {
        public static void Execute()
        {
            var monster =
                EntityManager.MinionsAndMonsters.Monsters.Where(m => m.IsValidTarget(Ryze.E.Range) && !m.IsDead)
                    .OrderBy(m => m.Health)
                    .Reverse()
                    .FirstOrDefault();

            if (monster == null) return;

            if (Ryze.R.IsReady() && Player.Instance.ManaPercent >= 15)
            {
                Ryze.R.Cast();
            }

            if (Player.Instance.HasBuff("RyzePassiveCharged") || Player.Instance.HasBuff("RyzeR"))
            {
                if (Ryze.Q.IsReady())
                {
                    Ryze.Q.Cast(monster);
                }
                if (Ryze.W.IsReady())
                {
                    Ryze.W.Cast(monster);
                }
                if (Ryze.E.IsReady())
                {
                    Ryze.E.Cast(monster);
                }
            }
            else
            {
                if (Ryze.Q.IsReady())
                {
                    Ryze.Q.Cast(monster);
                }
                if (Ryze.E.IsReady())
                {
                    Ryze.E.Cast(monster);
                }
            }
        }
    }
}