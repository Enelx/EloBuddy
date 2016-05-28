using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

namespace FAKERyze.Modes
{
    internal class PermaActive
    {
        public static void Execute()
        {
            if (Player.Instance.IsInShopRange() && Ryze.Q.IsReady())
            {
                Ryze.Q.Cast(Game.CursorPos);
            }

            foreach (
                var target in
                    EntityManager.Heroes.Enemies.Where(
                        t => t.IsValidTarget(Ryze.Q.Range) && !t.IsDead && !t.IsZombie && !t.IsInvulnerable))
            {
                if (Ryze.Q.IsReady() &&
                    target.TotalShieldHealth() <= Player.Instance.GetSpellDamage(target, SpellSlot.Q))
                {
                    Ryze.Q.Cast(target.ServerPosition);
                }
                if (Ryze.E.IsReady() &&
                    target.TotalShieldHealth() <= Player.Instance.GetSpellDamage(target, SpellSlot.E))
                {
                    Ryze.E.Cast(target);
                }
                if (Ryze.W.IsReady() &&
                    target.TotalShieldHealth() <= Player.Instance.GetSpellDamage(target, SpellSlot.W))
                {
                    Ryze.W.Cast(target);
                }
            }
        }
    }
}