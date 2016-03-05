using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Modes.Combo
{
    public static class Burst
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo) && ModeController.Mode == 4;
        }

        public static void Execute()
        {
            var target =
                Logic.CloseEnemies(Spells.Flash.Range, Player.Instance.ServerPosition).FirstOrDefault();
            var combobox = MenuDesigner.ComboUi["Burst.switcher"].Cast<ComboBox>().SelectedText;
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
            }
        }

        #region First Mode (E-R1-FLASH-Q-W-AA-HYDRA-R2-Q-AA-Q-AA) 

        private static void FirstMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Flash.Range)) return;

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
                target.Autoattack();
                Spells.Q.Cast(target.ServerPosition);
            }
        }

        #endregion

        #region Second Mode (Q-E-R1-flash-W-AA-hydra-Q-AA-R2-Q-AA) 

        private static void SecondMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Flash.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
            }
            else if (Spells.E.IsReady())
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

        #region Third Mode (E-R1-FLASH-HYDRA-W-Q-AA-R-Q-AA-Q-AA)

        private static void ThirdMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Flash.Range)) return;

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
            else if (Items.Tiamat.IsReady())
            {
                Items.Tiamat.Cast();
            }
            else if (Items.Hydra.IsReady())
            {
                Items.Hydra.Cast();
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
            }
            else if (Spells.Q.IsReady())
            {
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
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
        }

        #endregion
    }
}