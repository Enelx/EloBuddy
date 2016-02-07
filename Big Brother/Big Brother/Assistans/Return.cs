using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Big_Brother
{
    public static class Return
    {
        // Return Checkbox Value
        public static bool GetCheckbox(Menu menu, string menuvalue)
        { return menu[menuvalue].Cast<CheckBox>().CurrentValue; }

        // Return Keybind Value
        public static bool GetKeybind(Menu menu, string menuvalue)
        { return menu[menuvalue].Cast<KeyBind>().CurrentValue; }

        // Return Slider Value
        public static int GetSlider(Menu menu, string menuvalue)
        { return menu[menuvalue].Cast<Slider>().CurrentValue; }

        // Return Spy Menu :: X pos
        public static int SpyXpos
        { get { return GetSlider(MenuDesigner.SpyUI, "posX"); } }

        // Return Spy Menu :: Y pos
        public static int SpyYpos
        { get { return GetSlider(MenuDesigner.SpyUI, "posY"); } }

        // Return Spy Menu :: Enable Spy
        public static bool SpyEnable
        { get { return GetKeybind(MenuDesigner.SpyUI, "UseSpy"); } }

        // Return Spy Menu :: Health
        public static bool SpyHealth
        { get { return GetCheckbox(MenuDesigner.SpyUI, "SpyH"); } }

        // Return Spy Menu :: Flash
        public static bool SpyFlash
        { get { return GetCheckbox(MenuDesigner.SpyUI, "SpyF"); } }

        // Return Spy Menu :: Ultimate
        public static bool SpyUltimate
        { get { return GetCheckbox(MenuDesigner.SpyUI, "SpyR"); } }

    }
}
