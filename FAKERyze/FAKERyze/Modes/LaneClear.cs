using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace FAKERyze.Modes
{
    internal class LaneClear
    {
        public static void Execute()
        {
            var minions =
                EntityManager.MinionsAndMonsters.Minions.Where(
                    m => m.IsValidTarget(Ryze.Q.Range) && !m.IsDead && m.IsEnemy).ToList();

            if (Ryze.R.IsReady() && Player.Instance.CountEnemiesInRange(Ryze.Q.Range) == 0 &&
                Player.Instance.ManaPercent >= 20)
            {
                var count =
                    EntityManager.MinionsAndMonsters.GetLaneMinions()
                        .Count(m => m.IsValidTarget(Ryze.E.Range) && m.IsEnemy);

                if (count >= 4)
                {
                    Ryze.R.Cast();
                }
            }

            if (Player.Instance.HasBuff("RyzePassiveCharged") || Player.Instance.HasBuff("RyzeR"))
            {
                foreach (var m in minions)
                {
                    if (Ryze.Q.IsReady())
                    {
                        Ryze.Q.Cast(m);
                    }
                    if (Ryze.E.IsReady() && Ryze.E.IsInRange(m))
                    {
                        Ryze.E.Cast(m);
                    }
                    if (Ryze.W.IsReady() && Ryze.W.IsInRange(m))
                    {
                        Ryze.W.Cast(m);
                    }
                }
            }
            else
            {
                foreach (var m in minions)
                {
                    if (Ryze.Q.IsReady() && Player.Instance.Mana >
                        Ryze.Q.Handle.SData.Mana + Ryze.W.Handle.SData.Mana + Ryze.E.Handle.SData.Mana)
                    {
                        if (m.Health < Player.Instance.GetSpellDamage(m, SpellSlot.Q))
                        {
                            Ryze.Q.Cast(m);
                        }
                        else if
                            (m.Health > Player.Instance.GetSpellDamage(m, SpellSlot.Q) &&
                             Player.Instance.GetAutoAttackDamage(m) > m.Health)
                        {
                            Ryze.Q.Cast(m);
                        }
                    }

                    if (Ryze.E.IsReady() && Ryze.E.IsInRange(m) && Player.Instance.Mana >
                        Ryze.Q.Handle.SData.Mana + Ryze.W.Handle.SData.Mana + Ryze.E.Handle.SData.Mana)
                    {
                        Ryze.E.Cast(m);
                    }
                }
            }
        }
    }
}