using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Predator_Rengar
{
    public static class MenuDesigner
    {
        public const string MenuName = "Predator Rengar";

        public static readonly Menu RengarUI, ComboUI, ClearUI, MiscUI;

        static MenuDesigner()
        {
            // Predator Rengar :: Main Menu
            RengarUI = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            RengarUI.AddGroupLabel("Tonight we hunt !");
            RengarUI.AddSeparator();
            RengarUI.AddLabel("Developer    :   Enelx");
            RengarUI.AddLabel("Version          :   1.0.1.0");

            // Predator Rengar :: Combo Menu
            ComboUI = RengarUI.AddSubMenu("Combo");
            ComboUI.AddGroupLabel("Combo :: Spells");
            ComboUI.Add("ComboQ", new CheckBox("Use Q"));
            ComboUI.Add("ComboW", new CheckBox("Use W"));
            ComboUI.Add("ComboE", new CheckBox("Use E"));
            ComboUI.AddSeparator();
            ComboUI.AddGroupLabel("Combo :: Mode");
            ComboUI.Add("OneShot", new KeyBind("Enable One Shot", false, KeyBind.BindTypes.PressToggle, "T".ToCharArray()[0]));

            // Predator Rengar :: Clear Menu
            ClearUI = RengarUI.AddSubMenu("Clear");
            ClearUI.AddGroupLabel("Clear :: Spells");
            ClearUI.Add("ClearQ", new CheckBox("Use Q"));
            ClearUI.Add("ClearW", new CheckBox("Use W"));
            ClearUI.Add("ClearE", new CheckBox("Use E"));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Clear :: Ferocity");
            ClearUI.Add("SaveFerocity", new CheckBox("Save Ferocity"));

            // Predator Rengar :: Misc Menu
            MiscUI = RengarUI.AddSubMenu("Misc");
            MiscUI.AddGroupLabel("Misc :: Settings");
            MiscUI.Add("AutoHeal", new Slider("Auto heal %", 20, 0, 100));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Items");
            MiscUI.Add("UseTiamat", new CheckBox("Use Tiamat"));
            MiscUI.Add("UseHydra", new CheckBox("Use Hydra"));
            MiscUI.Add("UseTitanic", new CheckBox("Use Titanic"));
            MiscUI.Add("UseYoumuus", new CheckBox("Use Youmuu's"));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Draw");
            MiscUI.Add("DrawCombo", new CheckBox("Draw Combo Mode"));
        }

        public static void Initialize()
        {
        }
    }
}
