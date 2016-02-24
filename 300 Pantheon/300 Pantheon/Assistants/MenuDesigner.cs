using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace _300_Pantheon
{
    public static class MenuDesigner
    {
        public const string MenuName = "300 Pantheon";

        public static readonly Menu PantheonUI, ComboUI, HarassUI, ClearUI, KsUI, MiscUI;

        static MenuDesigner()
        {
            // 300 Pantheon :: Main Menu
            PantheonUI = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            PantheonUI.AddGroupLabel("THIS IS SCRIPTED !!!");
            PantheonUI.AddSeparator();
            PantheonUI.AddLabel("Developer    :   Enelx");
            PantheonUI.AddLabel("Version          :   1.0.0.0");

            // 300 Pantheon :: Combo Menu
            ComboUI = PantheonUI.AddSubMenu("Combo");
            ComboUI.AddGroupLabel("Combo :: Spells");
            ComboUI.Add("ComboQ", new CheckBox("Use Q"));
            ComboUI.Add("ComboW", new CheckBox("Use W"));
            ComboUI.Add("ComboE", new CheckBox("Use E"));

            // 300 Pantheon :: Harass Menu
            HarassUI = PantheonUI.AddSubMenu("Harass");
            HarassUI.AddGroupLabel("Harass :: Spells");
            HarassUI.Add("HarassQ", new CheckBox("Use Q"));
            HarassUI.AddSeparator();
            HarassUI.AddGroupLabel("Harass :: Settings");
            HarassUI.Add("ToggleHarass", new KeyBind("Toggle Harass", false, KeyBind.BindTypes.PressToggle, "T".ToCharArray()[0]));
            HarassUI.AddSeparator();
            HarassUI.Add("HarassMana", new Slider("Mana Min. %", 40, 0, 100));

            // 300 Pantheon :: Clear Menu
            ClearUI = PantheonUI.AddSubMenu("Clear");
            ClearUI.AddGroupLabel("Last Hit :: Spells");
            ClearUI.Add("LastQ", new CheckBox("Use Q"));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Lane Clear :: Spells");
            ClearUI.Add("ClearQ", new CheckBox("Use Q"));
            ClearUI.Add("ClearW", new CheckBox("Use W"));
            ClearUI.Add("ClearE", new CheckBox("Use E"));
            ClearUI.AddSeparator();
            ClearUI.Add("ClearMana", new Slider("Mana Min. %", 50, 0, 100));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Jungle Clear :: Spells");
            ClearUI.Add("JungleQ", new CheckBox("Use Q"));
            ClearUI.Add("JungleW", new CheckBox("Use W"));
            ClearUI.Add("JungleE", new CheckBox("Use E"));

            // 300 Pantheon :: Killsteal Menu
            KsUI = PantheonUI.AddSubMenu("Killsteal");
            KsUI.AddGroupLabel("Killsteal :: Spells");
            KsUI.Add("KsQ", new CheckBox("Use Q"));
            KsUI.Add("KsW", new CheckBox("Use W"));

            // 300 Pantheon :: Misc Menu
            MiscUI = PantheonUI.AddSubMenu("Misc");
            MiscUI.AddGroupLabel("Misc :: Settings");
            MiscUI.Add("InterW", new CheckBox("Use W for Interrupt"));
            MiscUI.Add("GapW", new CheckBox("Use W for Anti Gapclose"));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Items");
            MiscUI.Add("UseItems", new CheckBox("Use Agressive Items"));
            MiscUI.AddSeparator();
            MiscUI.AddGroupLabel("Misc :: Draw");
            MiscUI.Add("DrawSpells", new CheckBox("Draw Q W E"));
        }

        public static void Initialize()
        {
        }
    }
}
