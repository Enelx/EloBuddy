using System;
using Broken_Blade_Riven.Modes;
using EloBuddy;
using EloBuddy.SDK;

namespace Broken_Blade_Riven.Assistants
{
    public static class ModeController
    {
        static ModeController()
        {
            Game.OnTick += OnTick;
        }

        private static void OnTick(EventArgs args)
        {
            if (Return.Activemode(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.Flee))
            {
                Flee.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.LaneClear))
            {
                Clear.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.JungleClear))
            {
                Jungle.Execute();
            }

            PermaActive.Execute();
        }

        public static void Initialize()
        {
        }
    }
}