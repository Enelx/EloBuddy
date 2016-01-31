using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Predator_Rengar.Modes
{
    public static class LaneClear
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbLaneClear;
        }

        public static void Execute()
        {
            if (!Return.ClearSaveFerocity || !Return.HaveFullFerocity)
            {
                if (Spells.W.IsReady() && Return.UseWClear)
                {
                    var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, 400).OrderByDescending(a => a.MaxHealth).FirstOrDefault();
                    var creep = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, 400).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

                    if (creep != null)
                    {
                        if (creep.IsValidTarget())
                        {
                            Spells.W.Cast();
                            return;
                        }
                    }

                    if (minion != null)
                    {
                        if (minion.IsValidTarget())
                        {
                            if (Player.Instance.GetSpellDamage(minion, SpellSlot.W) > minion.Health)
                            {
                                Spells.W.Cast();
                                return;
                            }
                        }
                    }
                }

                if (Spells.E.IsReady() && Return.UseEClear)
                {
                    var minion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, 950).OrderByDescending(a => a.MaxHealth).FirstOrDefault();
                    var creep = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, 950).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

                    if (creep != null)
                    {
                        Spells.E.Cast(creep.ServerPosition);
                    }

                    if (minion != null)
                    {
                        if (Player.Instance.GetSpellDamage(minion, SpellSlot.E) > minion.Health)
                            Spells.E.Cast(minion.ServerPosition);
                    }
                }
            }
        }
    }
}
