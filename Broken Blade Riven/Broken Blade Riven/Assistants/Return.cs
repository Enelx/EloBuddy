using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Assistants
{
    public static class Return
    {
        /// <summary>
        ///     This function will make the life easy just checking the active mode instead of create 1000 bools
        /// </summary>
        /// <param name="id">Flag id of the orbwalker</param>
        /// <returns></returns>
        public static bool Activemode(Orbwalker.ActiveModes id)
        {
            return Orbwalker.ActiveModesFlags.HasFlag(id);
        }

        #region Clear

        // Clear Q
        public static bool UseQClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "ClearQ"); }
        }

        // Clear W
        public static bool UseWClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "ClearW"); }
        }

        // Clear E
        public static bool UseEClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "ClearE"); }
        }

        // Jungle Q
        public static bool UseQJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "JungleQ"); }
        }

        // Jungle W
        public static bool UseWJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "JungleW"); }
        }

        // Jungle E
        public static bool UseEJungle
        {
            get { return GetCheckbox(MenuDesigner.ClearUi, "JungleE"); }
        }

        #endregion

        #region Misc

        // Misc W Interrupt
        public static bool UseWInterrupt
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "InterW"); }
        }

        // Misc W/Q2 Anti Gapclose
        public static bool UseGapclose
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "GapWQ"); }
        }

        // Misc Use Items
        public static bool UseAgressiveItems
        {
            get { return GetCheckbox(MenuDesigner.MiscUi, "UseItems"); }
        }

        #endregion

        #region Menu Values

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

        #endregion
    }
}