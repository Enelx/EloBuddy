using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Black_Swan_Akali.Assistants
{
    public static class MenuDesigner
    {
        public const string MenuName = "Black Swan Akali";

        public static readonly Menu AkaliUi, ComboUi, HarassUi, ClearUi, KsUi, MiscUi;

        static MenuDesigner()
        {
            // Black Swan Akali :: Main Menu
            AkaliUi = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            AkaliUi.AddGroupLabel("As balance dictates.");
            AkaliUi.AddSeparator();
            AkaliUi.AddLabel("Developer    :   Enelx");
            AkaliUi.AddLabel("Version          :   2.0.0.0");

            // Black Swan Akali :: Combo Menu
            ComboUi = AkaliUi.AddSubMenu("Combo");
            ComboUi.AddGroupLabel("Combo :: Spells");
            ComboUi.Add("ComboQ", new CheckBox("Use Q"));
            ComboUi.Add("ComboW", new CheckBox("Use W"));
            ComboUi.Add("ComboE", new CheckBox("Use E"));
            ComboUi.Add("ComboR", new CheckBox("Use R"));

            // Black Swan Akali :: Harass Menu
            HarassUi = AkaliUi.AddSubMenu("Harass");
            HarassUi.AddGroupLabel("Harass :: Spells");
            HarassUi.Add("HarassQ", new CheckBox("Use Q"));

            // Black Swan Akali :: Clear Menu
            ClearUi = AkaliUi.AddSubMenu("Clear");
            ClearUi.AddGroupLabel("Last Hit :: Spells");
            ClearUi.Add("LastQ", new CheckBox("Use Q"));
            ClearUi.Add("LastE", new CheckBox("Use E", false));
            ClearUi.AddSeparator();
            ClearUi.AddGroupLabel("Lane Clear :: Spells / Settings");
            ClearUi.Add("ClearQ", new CheckBox("Use Q"));
            ClearUi.Add("ClearE", new CheckBox("Use E"));
            ClearUi.Add("ClearMana", new Slider("Energy Min. %", 25));
            ClearUi.AddSeparator();
            ClearUi.AddGroupLabel("Jungle Clear :: Spells / Settings");
            ClearUi.Add("JungleQ", new CheckBox("Use Q"));
            ClearUi.Add("JungleE", new CheckBox("Use E"));
            ClearUi.Add("JungleMana", new Slider("Energy Min. %", 10));

            // Black Swan Akali :: Killsteal Menu
            KsUi = AkaliUi.AddSubMenu("Killsteal");
            KsUi.AddGroupLabel("Killsteal :: Spells");
            KsUi.Add("KsQ", new CheckBox("Use Q"));
            KsUi.Add("KsR", new CheckBox("Use R"));

            // Black Swan Akali :: Misc Menu
            MiscUi = AkaliUi.AddSubMenu("Misc");
            MiscUi.AddGroupLabel("Misc :: Settings");
            MiscUi.Add("GapR", new CheckBox("Use R for Anti Gapclose"));
            MiscUi.Add("FleeW", new CheckBox("Use W on Flee"));
            MiscUi.AddSeparator();
            MiscUi.AddGroupLabel("Misc :: Items");
            MiscUi.Add("UseItems", new CheckBox("Use Agressive Items"));
            MiscUi.AddSeparator();
            MiscUi.AddGroupLabel("Misc :: Draw");
            MiscUi.Add("DrawQ", new CheckBox("Draw Q"));
            MiscUi.Add("DrawR", new CheckBox("Draw R"));
        }

        public static void Initialize()
        {
        }
    }
}