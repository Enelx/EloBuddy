using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Big_Brother
{
    public static class MenuDesigner
    {
        public const string MenuName = "Big Brother";

        public static readonly Menu BigBroUI, SpyUI;

        static MenuDesigner()
        {
            // Big Brother :: Main Menu
            BigBroUI = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            BigBroUI.AddGroupLabel("Your RIOT Secret Service");
            BigBroUI.AddSeparator();
            BigBroUI.AddLabel("Developer    :   Enelx");
            BigBroUI.AddLabel("Version          :   1.0.0.0");

            // Big Brother :: Spy Menu
            SpyUI = BigBroUI.AddSubMenu("Spy");
            SpyUI.AddGroupLabel("Spy :: Position");
            SpyUI.Add("posX", new Slider("Adjust - X", 50, 0, 100));
            SpyUI.Add("posY", new Slider("Adjust - Y", 10, 0, 100));
            SpyUI.AddSeparator();
            SpyUI.AddGroupLabel("Spy :: Service");
            SpyUI.Add("UseSpy", new KeyBind("Enable Spy", true, KeyBind.BindTypes.PressToggle, "S".ToCharArray()[0]));
            SpyUI.AddSeparator();
            SpyUI.Add("SpyH", new CheckBox("Spy enemy life"));
            SpyUI.Add("SpyF", new CheckBox("Spy enemy flash cdr"));
            SpyUI.Add("SpyR", new CheckBox("Spy enemy ultimate cdr"));
        }

        public static void Initialize()
        {
        }
    }
}
