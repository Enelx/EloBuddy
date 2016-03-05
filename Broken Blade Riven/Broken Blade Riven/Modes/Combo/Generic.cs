using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Modes.Combo
{
    public static class Generic
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo) && ModeController.Mode == 1;
        }

        public static void Execute()
        {
            var target =
                Logic.CloseEnemies(Spells.Q.Range + Spells.E.Range, Player.Instance.ServerPosition).FirstOrDefault();
            var combobox = MenuDesigner.ComboUi["Generic.switcher"].Cast<ComboBox>().SelectedText;
            switch (combobox)
            {
                case "First":
                    FirstMode(target);
                    break;
                case "Second":
                    SecondMode(target);
                    break;
                case "Third":
                    ThirdMode(target);
                    break;
                case "Fourth":
                    FourthMode(target);
                    break;
                case "Fifth":
                    FifthMode(target);
                    break;
            }
        }

        #region First Mode (E-R-AA-HYDRA-Q-AA-Q-W-AA-R-Q-AA) 

        private static void FirstMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Q.Range + Spells.E.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
                target.Autoattack();
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
                Spells.Q.Cast(target.ServerPosition);
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
                target.Autoattack();
            }
            else if (Spells.R2.IsReady())
            {
                var pred = Spells.R2.GetPrediction(target);

                Spells.R2.Cast(pred.CastPosition);
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
        }

        #endregion

        #region Second Mode (E-R-AA-HYDRA-Q-AA-W-AA-Q-AA-Q-AA-R-Q-AA)

        private static void SecondMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Q.Range + Spells.E.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
                target.Autoattack();
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
                target.Autoattack();
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.R2.IsReady())
            {
                var pred = Spells.R2.GetPrediction(target);

                Spells.R2.Cast(pred.CastPosition);
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
        }

        #endregion

        #region Third Mode (E-R-HYDRA-Q-AA-Q-AA-Q-AA-W-AA-R-AA)

        private static void ThirdMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Q.Range + Spells.E.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
                target.Autoattack();
            }
            else if (Spells.R2.IsReady())
            {
                var pred = Spells.R2.GetPrediction(target);

                Spells.R2.Cast(pred.CastPosition);
                target.Autoattack();
            }
        }

        #endregion

        #region Fourth Mode (E-R-Q-W-AA-HYDRA-R-Q)

        private static void FourthMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Q.Range + Spells.E.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
                target.Autoattack();
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Spells.R2.IsReady())
            {
                var pred = Spells.R2.GetPrediction(target);

                Spells.R2.Cast(pred.CastPosition);
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
            }
        }

        #endregion

        #region Fifth Mode (E-R-FLASH-Q-AA-W-R-HYDRA-AA)

        private static void FifthMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Q.Range + Spells.E.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
            }
            else if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
            }
            else if (Spells.Flash.IsReady())
            {
                Spells.Flash.Cast(target.ServerPosition);
            }
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
            }
            else if (Spells.R2.IsReady())
            {
                var pred = Spells.R2.GetPrediction(target);

                Spells.R2.Cast(pred.CastPosition);
            }
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
                target.Autoattack();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
                target.Autoattack();
            }
        }

        #endregion
    }
}