using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Assistants
{
    public static class MenuDesigner
    {
        public const string MenuName = "Broken Blade Riven";

        public static readonly Menu RivenUi, ComboUi, ClearUi, KsUI, MiscUi;

        static MenuDesigner()
        {
            // Broken Blade Riven :: Main Menu
            RivenUi = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            RivenUi.AddGroupLabel("What is broken can be reforged!");
            RivenUi.AddSeparator();
            RivenUi.AddLabel("Developer    :   Enelx");
            RivenUi.AddLabel("Version          :   1.0.0.0");

            ComboUi = RivenUi.AddSubMenu("Combo");
            ComboUi.AddGroupLabel("Combo :: Settings");
            ComboUi.AddSeparator();
            ComboUi.AddLabel("Generic Combo Mode:");
            ComboUi.AddLabel("Gapclose + most dmg output over time");
            ComboUi.AddLabel("First Mode (E-R1-AA-HYDRA-Q-AA-Q-W-AA-R2-Q-AA)");
            ComboUi.AddLabel("Keep the enemy closer to you, early stun");
            ComboUi.AddLabel("Second Mode (E-R1-AA-HYDRA-Q-AA-W-AA-Q-AA-Q-AA-R2-Q-AA)");
            ComboUi.AddLabel("Enemy cant flash R2 cause stunned");
            ComboUi.AddLabel("Third Mode (E-R1-HYDRA-Q-AA-Q-AA-Q-AA-W-AA-R2-AA)");
            ComboUi.AddLabel("Skip Q-AA for higher burst");
            ComboUi.AddLabel("Fourth Mode (E-R1-Q-W-AA-HYDRA-R2-Q)");
            ComboUi.AddLabel("Teamfight combo for more enemys");
            ComboUi.AddLabel("Fifth Mode (E-R1-FLASH-Q-AA-W-R2-HYDRA-AA)");
            ComboUi.Add("Generic.switcher",
                new ComboBox("Generic mode", new[] {"First", "Second", "Third", "Fourth", "Fifth"}));
            ComboUi.AddSeparator();
            ComboUi.AddLabel("Flash Combo Mode:");
            ComboUi.AddLabel("Use Flash combo when u are not fed, instead of Burst combo");
            ComboUi.AddLabel("First Mode (Q-Q-E-R1-FLASH-Q-AA-W-HYDRA-R2-AA");
            ComboUi.Add("Flash.switcher", new ComboBox("Flash mode", new[] {"First"}));
            ComboUi.AddSeparator();
            ComboUi.AddLabel("In Range Combo Mode:");
            ComboUi.AddLabel("While camping in a bush or enemy is in range");
            ComboUi.AddLabel("First Mode (R1-W-AA-HYDRA-Q-AA-E-AA-Q-AA-Q-AA-R2-Q-AA)");
            ComboUi.AddLabel("Use this vs Irelia, Renekton, Pantheon");
            ComboUi.AddLabel("Second Mode (R-W-AA-HYDRA-Q-AA-E-AA-Q-AA-Q-AA-R)");
            ComboUi.Add("Range.switcher", new ComboBox("Range mode", new[] {"First", "Second"}));
            ComboUi.AddSeparator();
            ComboUi.AddLabel("Burst Combo Mode:");
            ComboUi.AddLabel("The Shy combo");
            ComboUi.AddLabel("First Mode (E-R1-FLASH-Q-W-AA-FLASH-R2-Q-AA-Q-AA)");
            ComboUi.AddLabel("The Shy combo + Q to gap closer");
            ComboUi.AddLabel("Second Mode (Q-E-R1-FLASH-W-AA-HYDRA-Q-AA-R2-Q-AA)");
            ComboUi.AddLabel("Doublecast combo, hardest on Riven");
            ComboUi.AddLabel("Third Mode (E-R1-FLASH-W-AA-Q-AA-Q-AA-Q-R2 )");
            ComboUi.Add("Burst.switcher",
                new ComboBox("Burst mode", new[] {"First", "Second", "Third"}));
            ComboUi.AddSeparator();
            ComboUi.AddGroupLabel("Keybind Settings");
            ComboUi.Add("switchCombo",
                new KeyBind("Switch Combo mode", false, KeyBind.BindTypes.HoldActive, 'T'))
                .OnValueChange += ModeController.ModeSwitch;

            ClearUi = RivenUi.AddSubMenu("Clear");
            ClearUi.AddGroupLabel("Lane Clear :: Spells");
            ClearUi.Add("ClearQ", new CheckBox("Use Q"));
            ClearUi.Add("ClearW", new CheckBox("Use W"));
            ClearUi.Add("ClearE", new CheckBox("Use E"));
            ClearUi.AddSeparator();
            ClearUi.AddGroupLabel("Jungle Clear :: Spells");
            ClearUi.Add("JungleQ", new CheckBox("Use Q"));
            ClearUi.Add("JungleW", new CheckBox("Use W"));
            ClearUi.Add("JungleE", new CheckBox("Use E"));

            MiscUi = RivenUi.AddSubMenu("Misc");
            MiscUi.AddGroupLabel("Misc :: Settings");
            MiscUi.Add("InterW", new CheckBox("Use W for Interrupt"));
            MiscUi.Add("GapWQ", new CheckBox("Use W/Q2 for Anti Gapclose"));
            MiscUi.AddGroupLabel("Misc :: Items");
            MiscUi.Add("UseItems", new CheckBox("Use Agressive Items"));
        }

        public static void Initialize()
        {
        }
    }
}