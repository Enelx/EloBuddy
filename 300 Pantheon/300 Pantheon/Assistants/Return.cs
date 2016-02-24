using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace _300_Pantheon
{
    public static class Return
    {
        // Return Checkbox Value
        public static bool GetCheckbox(Menu menu, string menuvalue)
        {
            return menu[menuvalue].Cast<CheckBox>().CurrentValue;
        }

        // Return Keybind Value
        public static bool GetKeybind(Menu menu, string menuvalue)
        {
            return menu[menuvalue].Cast<KeyBind>().CurrentValue;
        }

        // Return Slider Value
        public static int GetSlider(Menu menu, string menuvalue)
        {
            return menu[menuvalue].Cast<Slider>().CurrentValue;
        }

        // Combo Q
        public static bool UseQCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboQ"); }
        }

        // Combo W
        public static bool UseWCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboW"); }
        }

        // Combo E
        public static bool UseECombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboE"); }
        }

        // Harass Q
        public static bool UseQHarass
        {
            get { return GetCheckbox(MenuDesigner.HarassUI, "HarassQ"); }
        }

        // Harass Toggle
        public static bool HarassToggle
        {
            get { return GetKeybind(MenuDesigner.HarassUI, "ToggleHarass"); }
        }

        // Harass Min. Mana
        public static int HarassManaMin
        {
            get { return GetSlider(MenuDesigner.HarassUI, "HarassMana"); }
        }

        // Lasthit Q
        public static bool UseQLast
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "LastQ"); }
        }

        // Clear Q
        public static bool UseQClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearQ"); }
        }

        // Clear W
        public static bool UseWClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearW"); }
        }

        // Clear E
        public static bool UseEClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearE"); }
        }

        // Clear Min. Mana
        public static int ClearManaMin
        {
            get { return GetSlider(MenuDesigner.ClearUI, "ClearMana"); }
        }

        // Jungle Q
        public static bool UseQJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "JungleQ"); }
        }

        // Jungle W
        public static bool UseWJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "JungleW"); }
        }

        // Jungle E
        public static bool UseEJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "JungleE"); }
        }

        // KS Q
        public static bool UseQKs
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsQ"); }
        }

        // KS W
        public static bool UseWKs
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsW"); }
        }

        // Misc W Interrupt
        public static bool UseWInterrupt
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "InterW"); }
        }

        // Misc W Anti Gapclose
        public static bool UseWGapclose
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "GapW"); }
        }

        // Misc Use Items
        public static bool UseAgressiveItems
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "UseItems"); }
        }

        // Misc Draw Q W E
        public static bool DrawQWERange
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "DrawSpells"); }
        }
    }
}
