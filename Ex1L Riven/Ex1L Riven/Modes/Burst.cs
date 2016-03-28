using EloBuddy;
using EloBuddy.SDK;
using Ex1L_Riven.Base;

namespace Ex1L_Riven.Modes
{
    internal class Burst
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.Activemode(Orbwalker.ActiveModes.Combo);
        }

        public static void Execute()
        {
            var target = TargetSelector.SelectedTarget;

            if (target != null && target.IsValidTarget(800))
            {
                if (Spells.E.IsReady())
                {
                    Spells.E.Cast(target.ServerPosition);
                }
                if (Spells.Flash.IsReady())
                {
                    Spells.Flash.Cast(target.ServerPosition);
                }

                if (target.IsValidTarget(Spells.W.Range))
                {
                    if (Spells.R1.IsReady() && Variables.UseRCombo && Riven.R1Activated == false)
                    {
                        Spells.R1.Cast();
                    }
                    if (Spells.W.IsReady())
                    {
                        Spells.W.Cast();
                    }
                    Player.IssueOrder(GameObjectOrder.AttackTo, target);
                    Logic.CastTiaHydra(target);

                    if (target.IsValidTarget(Spells.Q.Range))
                    {
                        if (Spells.R2.IsReady() && Riven.R1Activated)
                        {
                            var prediction = Spells.R2.GetPrediction(target);
                            Spells.R2.Cast(prediction.CastPosition);
                        }
                        if (Spells.Q.IsReady())
                        {
                            Spells.Q.Cast(target.ServerPosition);
                        }
                    }
                }

                Logic.CastQaa2(target);
            }
        }
    }
}