using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Black_Swan_Akali
{
    public static class MenuDesigner
    {
        public const string MenuName = "Black Swan Akali";

        public static readonly Menu AkaliUI, ComboUI, HarassUI, ClearUI, KsUI, MiscUI;

        static MenuDesigner()
        {
            // Black Swan Akali :: Main Menu
            AkaliUI = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            AkaliUI.AddGroupLabel("As balance dictates.");
            AkaliUI.AddSeparator();
            AkaliUI.AddLabel("Developer    :   Enelx");
            AkaliUI.AddLabel("Version          :   1.1.0.0");

            // Black Swan Akali :: Combo Menu
            ComboUI = AkaliUI.AddSubMenu("Combo");
            ComboUI.AddGroupLabel("Combo :: Spells");
            ComboUI.Add("ComboQ", new CheckBox("Use Q"));
            ComboUI.Add("ComboW", new CheckBox("Use W"));
            ComboUI.Add("ComboE", new CheckBox("Use E"));
            ComboUI.Add("ComboR", new CheckBox("Use R"));

            // Black Swan Akali :: Harass Menu
            HarassUI = AkaliUI.AddSubMenu("Harass");
            HarassUI.AddGroupLabel("Harass :: Spells");
            HarassUI.Add("HarassQ", new CheckBox("Use Q"));

            // Black Swan Akali :: Clear Menu
            ClearUI = AkaliUI.AddSubMenu("Clear");
            ClearUI.AddGroupLabel("Last Hit :: Spells");
            ClearUI.Add("LastQ", new CheckBox("Use Q"));
            ClearUI.Add("LastE", new CheckBox("Use E", false));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Lane Clear :: Spells / Settings");
            ClearUI.Add("ClearQ", new CheckBox("Use Q"));
            ClearUI.Add("ClearE", new CheckBox("Use E"));
            ClearUI.Add("ClearEmin", new Slider("Min. Minions for E", 2, 1, 6));
            ClearUI.Add("ClearMana", new Slider("Energy Min. %", 25, 0, 100));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Jungle Clear :: Spells / Settings");
            ClearUI.Add("JungleQ", new CheckBox("Use Q"));
            ClearUI.Add("JungleE", new CheckBox("Use E"));
            ClearUI.Add("JungleMana", new Slider("Energy Min. %", 10, 0, 100));

            // Black Swan Akali :: Killsteal Menu
            KsUI = AkaliUI.AddSubMenu("Killsteal");
            KsUI.AddGroupLabel("Killsteal :: Spells");
            KsUI.Add("KsQ", new CheckBox("Use Q"));
            KsUI.Add("KsR", new CheckBox("Use R"));

            // Black Swan Akali :: Misc Menu
            MiscUI = AkaliUI.AddSubMenu("Misc");
            MiscUI.AddGroupLabel("Misc :: Settings");
            MiscUI.Add("GapR", new CheckBox("Use R for Anti Gapclose"));
            MiscUI.Add("FleeW", new CheckBox("Use W on Flee"));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Items");
            MiscUI.Add("UseItems", new CheckBox("Use Agressive Items"));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Draw");
            MiscUI.Add("DrawQ", new CheckBox("Draw Q"));
            MiscUI.Add("DrawR", new CheckBox("Draw R"));
        }

        public static void Initialize()
        {
        }
    }
}
