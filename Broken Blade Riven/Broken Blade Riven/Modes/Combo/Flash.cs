using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Modes.Combo
{
    public static class Flash
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo) && ModeController.Mode == 2;
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.Flash.Range, Player.Instance.ServerPosition).FirstOrDefault();
            var combobox = MenuDesigner.ComboUi["Flash.switcher"].Cast<ComboBox>().SelectedText;
            switch (combobox)
            {
                case "First":
                    FirstMode(target);
                    break;
            }
        }

        #region First Mode (Q-Q-E-R-FLASH-Q-AA-W-HYDRA-R-AA)

        private static void FirstMode(AIHeroClient target)
        {
            if (target == null || !target.IsValidTarget(Spells.Flash.Range)) return;

            if (Return.UseAgressiveItems)
            {
                Items.CastItems(target);
            }

            if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
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
            else if (Spells.Q.IsReady())
            {
                Spells.Q.Cast(target.ServerPosition);
                target.Autoattack();
            }
            else if (Spells.W.IsReady())
            {
                Spells.W.Cast();
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
                target.Autoattack();
            }
        }

        #endregion
    }
}