using System;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Modes;

namespace _300_Pantheon.Assistants
{
    public static class ModeController
    {
        static ModeController()
        {
            Game.OnTick += OnTick;
        }

        // Return Orbwalker Modes
        public static bool OrbCombo
        {
            get { return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo); }
        }

        public static bool OrbHarass
        {
            get { return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass); }
        }

        public static bool OrbLaneClear
        {
            get { return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear); }
        }

        public static bool OrbJungleClear
        {
            get { return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear); }
        }

        public static bool OrbLastHit
        {
            get { return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit); }
        }

        private static void OnTick(EventArgs args)
        {
            if (OrbCombo)
            {
                Combo.Execute();
            }

            else if (OrbHarass || Return.HarassToggle)
            {
                Harass.Execute();
            }

            else if (OrbLaneClear)
            {
                Clear.Execute();
            }

            else if (OrbJungleClear)
            {
                Jungle.Execute();
            }

            else if (OrbLastHit)
            {
                Lasthit.Execute();
            }

            PermaActive.Execute();

        }


        public static void Initialize()
        {
        }
    }
}