using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Black_Swan_Akali.Assistants
{
    public static class Return
    {
        // Combo Q
        public static bool UseQCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUi, "ComboQ"); }
        }

        // Combo W
        public static bool UseWCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUi, "ComboW"); }
        }

        // Combo E
        public static bool UseECombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUi, "ComboE"); }
        }

        // Combo R
        public static bool UseRCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUi, "ComboR"); }
        }

        // Harass Q
        public static bool UseQHarass
        {
            get { return GetCheckbox(MenuDesigner.HarassUi, "HarassQ"); }
        }

        // Lasthit Q
        public static bool UseQLast
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "LastQ"); }
        }

        // Lasthit E
        public static bool UseELast
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "LastE"); }
        }

        // Clear Q
        public static bool UseQClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "ClearQ"); }
        }

        // Clear E
        public static bool UseEClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "ClearE"); }
        }

        // Clear Energy
        public static int ClearEnergyMin
        {
            get { return GetSlider(MenuDesigner.ClearUi, "ClearMana"); }
        }

        // Jungle Q
        public static bool UseQJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "JungleQ"); }
        }

        // Jungle E
        public static bool UseEJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "JungleE"); }
        }

        // Jungle Energy
        public static int JungleEnergyMin
        {
            get { return GetSlider(MenuDesigner.ClearUi, "JungleMana"); }
        }

        // KS Q
        public static bool UseQKs
        {
            get { return GetCheckbox(MenuDesigner.KsUi, "KsQ"); }
        }

        // KS R
        public static bool UseRKs
        {
            get { return GetCheckbox(MenuDesigner.KsUi, "KsR"); }
        }

        // Misc R Anti Gapclose
        public static bool UseRGapclose
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "GapR"); }
        }

        // Misc FLee
        public static bool UseWFlee
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "FleeW"); }
        }

        // Misc Draw Q
        public static bool DrawQRange
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "DrawQ"); }
        }

        // Misc Draw R
        public static bool DrawRRange
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "DrawR"); }
        }

        // Misc Use Items
        public static bool UseAgressiveItems
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "UseItems"); }
        }

        /// <summary>
        ///     This function will make the life easy just checking the active mode instead of create 1000 bools
        /// </summary>
        /// <param name="id">Flag id of the orbwalker</param>
        /// <returns></returns>
        public static bool Activemode(Orbwalker.ActiveModes id)
        {
            return Orbwalker.ActiveModesFlags.HasFlag(id);
        }

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
    }
}