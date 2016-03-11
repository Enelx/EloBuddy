using EloBuddy;
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
            RivenUi.AddLabel("Version          :   2.0.0.0");
            RivenUi.AddSeparator();
            RivenUi.AddLabel("Now full automatic");

            ComboUi = RivenUi.AddSubMenu("Combo");
            ComboUi.AddGroupLabel("Combo :: Settings");
            ComboUi.Add("ForceR", new CheckBox("Force R1"));
            ComboUi.Add("ComboFlash", new KeyBind("Use Flash in combo", false, KeyBind.BindTypes.PressToggle, 'T'))
                .OnValueChange += ModeSwitch;

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
            MiscUi.Add("GapWQ", new CheckBox("Use W for Anti Gapclose"));
            MiscUi.AddGroupLabel("Misc :: Items");
            MiscUi.Add("UseItems", new CheckBox("Use Agressive Items"));
        }

        public static void ModeSwitch(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
        {
            if (args.NewValue)
            {
                Chat.Print("Use flash in combo");
            }

            if (args.OldValue)
            {
                Chat.Print("Dont use flash in combo");
            }
        }

        public static void Initialize()
        {
        }
    }
}