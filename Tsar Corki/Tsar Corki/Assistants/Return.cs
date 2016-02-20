using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Tsar_Corki
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

        // Combo E
        public static bool UseECombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboE"); }
        }

        // Combo R
        public static bool UseRCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboR"); }
        }

        // Harass Q
        public static bool UseQHarass
        {
            get { return GetCheckbox(MenuDesigner.HarassUI, "HarassQ"); }
        }

        // Harass E
        public static bool UseEHarass
        {
            get { return GetCheckbox(MenuDesigner.HarassUI, "HarassE"); }
        }

        // Harass R
        public static bool UseRHarass
        {
            get { return GetCheckbox(MenuDesigner.HarassUI, "HarassR"); }
        }

        // Harass R Save
        public static int HarassRSave
        {
            get { return GetSlider(MenuDesigner.HarassUI, "StacksR"); }
        }

        // Harass Mana
        public static int HarassManaMin
        {
            get { return GetSlider(MenuDesigner.HarassUI, "HarassMana"); }
        }

        // Clear Q
        public static bool UseQClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearQ"); }
        }

        // Clear R
        public static bool UseRClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearR"); }
        }

        // Clear Mana
        public static int ClearManaMin
        {
            get { return GetSlider(MenuDesigner.ClearUI, "ClearMana"); }
        }

        // Jungle Q
        public static bool UseQJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "JungleQ"); }
        }

        // Jungle R
        public static bool UseRJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "JungleR"); }
        }

        // Jungle Mana
        public static int JungleManaMin
        {
            get { return GetSlider(MenuDesigner.ClearUI, "JungleMana"); }
        }

        // KS Q
        public static bool UseQKs
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsQ"); }
        }

        // KS R
        public static bool UseRKs
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsR"); }
        }

        // Misc FLee
        public static bool UseWFlee
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "FleeW"); }
        }

        // Misc Anti Gapclose
        public static bool UseWGapclose
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "AntiW"); }
        }

        // Misc Draw Q
        public static bool DrawQRange
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "DrawQ"); }
        }

        // Misc Draw R
        public static bool DrawRRange
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "DrawR"); }
        }
    }
}
