using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Modes.Combo
{
    public static class Range
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo) && ModeController.Mode == 3;
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.W.Range, Player.Instance.ServerPosition).FirstOrDefault();
            var combobox = MenuDesigner.ComboUi["Range.switcher"].Cast<ComboBox>().SelectedText;
            switch (combobox)
            {
                case "First":
                    FirstMode(target);
                    break;
                case "Second":
                    SecondMode(target);
                    break;
            }
        }

        #region First Mode (R-W-AA-HYDRA-Q-AA-E-AA-Q-AA-Q-AA-R-Q-AA) 

        private static void FirstMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.W.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
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
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
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

        #region Second Mode (R-W-AA-HYDRA-Q-AA-E-AA-Q-AA-Q-AA-R) 

        private static void SecondMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.W.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.R1.IsReady())
            {
                Spells.R1.Cast();
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
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.E.IsReady())
            {
                Spells.E.Cast(target.ServerPosition);
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
        }

        #endregion
    }
}