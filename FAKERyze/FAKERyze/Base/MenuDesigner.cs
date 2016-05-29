using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace FAKERyze.Base
{
    internal class MenuDesigner
    {
        public static Menu RyzeUi;
        public static Menu ConfigUi;

        internal static void Initialize()
        {
            RyzeUi = MainMenu.AddMenu("FAKERyze", "ryze", "Enelx FAKERyze");
            RyzeUi.AddGroupLabel("Fully automated Ryze addon");

            ConfigUi = RyzeUi.AddSubMenu("Config");
            ConfigUi.AddGroupLabel("Harass - Settings");
            ConfigUi.Add("HarassE", new CheckBox("Use E"));
            ConfigUi.AddGroupLabel("Draw - Settings");
            ConfigUi.Add("DrawQ", new CheckBox("Draw Q"));
        }
    }
}