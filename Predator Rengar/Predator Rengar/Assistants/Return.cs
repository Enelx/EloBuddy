using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Predator_Rengar
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

        // Return if Rengar has full Ferocity
        public static bool HaveFullFerocity
        {
            get { return ObjectManager.Player.Mana == 5; }
        }

        // Return Misc Menu :: Auto Heal
        public static int AutoHealPercent
        {
            get { return GetSlider(MenuDesigner.MiscUI, "AutoHeal"); }
        }

        // Return Misc Menu :: Interrupt E
        public static bool InterruptE
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "InterE"); }
        }

        // Return Misc Menu :: Draw Combo
        public static bool DrawComboMode
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "DrawCombo"); }
        }

        // Return Misc Menu :: Use Tiamat
        public static bool UseItemTiamat
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "UseTiamat"); }
        }

        // Return Misc Menu :: Use Hydra
        public static bool UseItemHydra
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "UseHydra"); }
        }

        // Return Misc Menu :: Use Titanic
        public static bool UseItemTitanic
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "UseTitanic"); }
        }

        // Return Misc Menu :: Use Youmuus
        public static bool UseItemYoumuus
        {
            get { return GetCheckbox(MenuDesigner.MiscUI, "UseYoumuus"); }
        }

        // Return Combo Menu :: One Shot
        public static bool OneShotActive
        {
            get { return GetKeybind(MenuDesigner.ComboUI, "OneShot"); }
        }

        // Return Combo Menu :: Use Q
        public static bool UseQCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboQ"); }
        }

        // Return Combo Menu :: Use W
        public static bool UseWCombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboW"); }
        }

        // Return Combo Menu :: Use E
        public static bool UseECombo
        {
            get { return GetCheckbox(MenuDesigner.ComboUI, "ComboE"); }
        }

        // Return Clear Menu :: Use Q
        public static bool UseQClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearQ"); }
        }

        // Return Clear Menu :: Use W
        public static bool UseWClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearW"); }
        }

        // Return Clear Menu :: Use E
        public static bool UseEClear
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "ClearE"); }
        }

        // Return Clear Menu :: Save Ferocity
        public static bool ClearSaveFerocity
        {
            get { return GetCheckbox(MenuDesigner.ClearUI, "SaveFerocity"); }
        }

        // Return Killsteal Menu :: Use W
        public static bool UseWSteal
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsW"); }
        }

        // Return Killsteal Menu :: Use E
        public static bool UseESteal
        {
            get { return GetCheckbox(MenuDesigner.KsUI, "KsE"); }
        }

        // Return Rengar Passive Buff or IsDashing
        public static bool WillLeap
        {
            get { return Player.Instance.HasBuff("rengarpassivebuff") || Player.Instance.IsDashing(); }
        }
    }
}
