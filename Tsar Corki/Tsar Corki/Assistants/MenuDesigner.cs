using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Tsar_Corki
{
    public static class MenuDesigner
    {
        public const string MenuName = "Tsar Corki";

        public static readonly Menu CorkiUI, ComboUI, HarassUI, ClearUI, KsUI, MiscUI;

        static MenuDesigner()
        {
            // Tsar Corki :: Main Menu
            CorkiUI = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            CorkiUI.AddGroupLabel("Ground Zero... Bombs away!");
            CorkiUI.AddSeparator();
            CorkiUI.AddLabel("Developer    :   Enelx");
            CorkiUI.AddLabel("Version          :   1.0.0.0");

            // Tsar Corki :: Combo Menu
            ComboUI = CorkiUI.AddSubMenu("Combo");
            ComboUI.AddGroupLabel("Combo :: Spells");
            ComboUI.Add("ComboQ", new CheckBox("Use Q"));
            ComboUI.Add("ComboE", new CheckBox("Use E"));
            ComboUI.Add("ComboR", new CheckBox("Use R"));

            // Tsar Corki :: Harass Menu
            HarassUI = CorkiUI.AddSubMenu("Harass");
            HarassUI.AddGroupLabel("Harass :: Spells");
            HarassUI.Add("HarassQ", new CheckBox("Use Q"));
            HarassUI.Add("HarassE", new CheckBox("Use E"));
            HarassUI.Add("HarassR", new CheckBox("Use R"));
            HarassUI.AddSeparator();
            HarassUI.AddGroupLabel("Harass :: Settings");
            HarassUI.Add("StacksR", new Slider("Save R Stacks Value", 3, 0, 7));
            HarassUI.Add("HarassMana", new Slider("Mana Min. %", 40, 0, 100));

            // Tsar Corki :: Clear Menu
            ClearUI = CorkiUI.AddSubMenu("Clear");
            ClearUI.AddGroupLabel("Lane Clear :: Spells");
            ClearUI.Add("ClearQ", new CheckBox("Use Q"));
            ClearUI.Add("ClearR", new CheckBox("Use R"));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Lane Clear :: Settings");
            ClearUI.Add("ClearMana", new Slider("Mana Min. %", 50, 0, 100));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Jungle Clear :: Spells");
            ClearUI.Add("JungleQ", new CheckBox("Use Q"));
            ClearUI.Add("JungleR", new CheckBox("Use R"));
            ClearUI.AddSeparator();
            ClearUI.AddGroupLabel("Jungle Clear :: Settings");
            ClearUI.Add("JungleMana", new Slider("Mana Min. %", 20, 0, 100));


            // Tsar Corki :: Killsteal Menu
            KsUI = CorkiUI.AddSubMenu("Killsteal");
            KsUI.AddGroupLabel("Killsteal :: Spells");
            KsUI.Add("KsQ", new CheckBox("Use Q"));
            KsUI.Add("KsR", new CheckBox("Use R"));

            // Tsar Corki :: Misc Menu
            MiscUI = CorkiUI.AddSubMenu("Misc");
            MiscUI.AddGroupLabel("Misc :: Settings");
            MiscUI.Add("FleeW", new CheckBox("Use W to Flee"));
            MiscUI.Add("AntiW", new CheckBox("Use W for Anti Gapclose"));
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
