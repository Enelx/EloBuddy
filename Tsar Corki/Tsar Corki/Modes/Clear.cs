using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;


namespace Tsar_Corki.Modes
{
    public static class Clear
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbLaneClear;
        }

        public static void Execute()
        {
            if (Player.Instance.ManaPercent < Return.ClearManaMin)
                return;

            var Qminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.Q.Range);
            var Rminion = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, Spells.R.Range);
            var Qpred = Prediction.Position.PredictCircularMissileAoe(Qminion.Cast<Obj_AI_Base>().ToArray(), Spells.Q.Range, Spells.Q.Radius, Spells.Q.CastDelay, Spells.Q.Speed).OrderByDescending(q => q.GetCollisionObjects<Obj_AI_Minion>().Length).FirstOrDefault();
            var Rpred = EntityManager.MinionsAndMonsters.GetLineFarmLocation(Rminion, Spells.R.Width, (int)Spells.R.Range);

            if (Qminion != null)
            {
                if (Spells.Q.IsReady() && Return.UseQClear)
                {
                    if (Qpred.CollisionObjects.Length >= 3)
                        Spells.Q.Cast(Qpred.CastPosition);
                }
            }

            if (Rminion != null)
            {
                if (Spells.R.IsReady() && Return.UseRClear && Spells.R.Handle.Ammo > 3)
                {
                    if (Rpred.HitNumber >= 3)
                        Spells.R.Cast(Rpred.CastPosition);
                }
            }
        }
    }
}
