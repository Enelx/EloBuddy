using EloBuddy;
using EloBuddy.SDK;


namespace _300_Pantheon
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

            if (OrbHarass || Return.HarassToggle)
                Modes.Harass.Execute();

            if (OrbLaneClear)
                Modes.Clear.Execute();

            if (OrbJungleClear)
                Modes.Jungle.Execute();

            if (OrbLastHit)
                Modes.Lasthit.Execute();
        }

        // Return Orbwalker Modes
        public static bool OrbCombo
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
            }
        }

        public static bool OrbHarass
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
            }
        }

        public static bool OrbLaneClear
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
            }
        }

        public static bool OrbJungleClear
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
            }
        }

        public static bool OrbLastHit
        {
            get
            {
                return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
            }
        }


        public static void Initialize()
        {
        }
    }
}
