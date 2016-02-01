using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace Predator_Rengar.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbCombo;
        }

        public static void Execute()
        {

            if (!Return.WillLeap)
            {
                var t = TargetSelector.GetTarget(Spells.E.Range, DamageType.Physical);

                if (TargetSelector.SelectedTarget.IsValidTarget(2500))
                    t = TargetSelector.SelectedTarget;

                if (t != null && t.IsValidTarget(Spells.E.Range) && Spells.E.IsReady() && (!Return.HaveFullFerocity || t.IsValidTarget(Player.Instance.GetAutoAttackRange(t))) && Return.UseECombo)
                {
                    var h = Spells.E.GetPrediction(t);

                    if (h.HitChance >= HitChance.High)
                        Spells.E.Cast(t.ServerPosition);
                }

 
                if (TargetSelector.SelectedTarget.IsValidTarget(2500))
                    t = TargetSelector.SelectedTarget;
                else
                    t = TargetSelector.GetTarget(Spells.W.Range, DamageType.Physical);

                if (t != null && t.IsValidTarget(Spells.W.Range) && Spells.W.IsReady() && !Return.HaveFullFerocity)
                    Spells.W.Cast();

                if (t != null && t.IsValidTarget(Spells.W.Range) && Item.HasItem(3142) && Item.CanUseItem(3142) && Return.UseItemYoumuus)
                    Item.UseItem(3142);
            }
        }
    }
}
