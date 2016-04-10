using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace _300_Pantheon.Base
{
    internal class MenuDesigner
    {
        public static Menu PantheonUi;
        public static Menu ComboUi;
        public static Menu HarassUi;
        public static Menu ClearUi;
        public static Menu KsUi;
        public static Menu MiscUi;

        internal static void Initialize()
        {
            PantheonUi = MainMenu.AddMenu("300 Pantheon", "panth", "Enelx 300 Pantheon");
            PantheonUi.AddGroupLabel("This is SCRIPTED !");

            ComboUi = PantheonUi.AddSubMenu("Combo");
            ComboUi.Add("ComboQ", new CheckBox("Use Q"));
            ComboUi.Add("ComboW", new CheckBox("Use W"));
            ComboUi.Add("ComboE", new CheckBox("Use E"));

            HarassUi = PantheonUi.AddSubMenu("Harass");
            HarassUi.AddGroupLabel("Harass :: Spells");
            HarassUi.Add("HarassQ", new CheckBox("Use Q"));
            HarassUi.AddSeparator();
            HarassUi.AddGroupLabel("Harass :: Config");
            HarassUi.Add("HarassMana", new Slider("Min. Mana %", 40));
            HarassUi.Add("HarassToggle",
                new KeyBind("Toggle Harass", false, KeyBind.BindTypes.PressToggle, "T".ToCharArray()[0]));

            ClearUi = PantheonUi.AddSubMenu("Clear");
            ClearUi.AddGroupLabel("Last Hit :: Spells");
            ClearUi.Add("ClearLastQ", new CheckBox("Use Q"));
            ClearUi.AddSeparator();
            ClearUi.AddGroupLabel("Lane Clear :: Spells");
            ClearUi.Add("ClearLaneQ", new CheckBox("Use Q"));
            ClearUi.Add("ClearLaneW", new CheckBox("Use W"));
            ClearUi.Add("ClearLaneE", new CheckBox("Use E"));
            ClearUi.AddSeparator();
            ClearUi.Add("ClearLanaMana", new Slider("Min. Mana %", 50));
            ClearUi.AddSeparator();
            ClearUi.AddGroupLabel("Jungle Clear :: Spells");
            ClearUi.Add("ClearJungleQ", new CheckBox("Use Q"));
            ClearUi.Add("ClearJungleW", new CheckBox("Use Q"));
            ClearUi.Add("ClearJungleE", new CheckBox("Use Q"));

            KsUi = PantheonUi.AddSubMenu("Killsteal");
            KsUi.Add("KsQ", new CheckBox("Use Q"));
            KsUi.Add("KsW", new CheckBox("Use W"));

            MiscUi = PantheonUi.AddSubMenu("Misc");
            MiscUi.AddGroupLabel("Misc :: Config");
            MiscUi.Add("InterW", new CheckBox("Use W for interrupt"));
            MiscUi.Add("GapW", new CheckBox("Use W as anti gapcloser"));
            MiscUi.Add("MiscItems", new CheckBox("Use Items"));
            MiscUi.AddSeparator();
            MiscUi.Add("MiscDrawQW", new CheckBox("Draw Q W"));
        }
    }
}