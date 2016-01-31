using EloBuddy;
using EloBuddy.SDK;

namespace Predator_Rengar
{
    public static class ModeController
    {
        static ModeController()
        {
            Game.OnTick += OnTick;
        }

        private static void OnTick(System.EventArgs args)
        {
            if (OrbCombo)
                Modes.Combo.Execute();

            if (OrbLaneClear)
                Modes.LaneClear.Execute();
        }

        // Return Orbwalker Modes
        public static bool OrbCombo
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
            }
        }

        public static bool OrbLaneClear
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
            }
        }

        public static void Initialize()
        {
        }
    }
}
