using System;
using Black_Swan_Akali.Modes;
using EloBuddy;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Assistants
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

            if (Return.Activemode(Orbwalker.ActiveModes.Harass))
            {
                Harass.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.LaneClear))
            {
                Clear.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.JungleClear))
            {
                Jungle.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.LastHit))
            {
                Lasthit.Execute();
            }

            if (Return.Activemode(Orbwalker.ActiveModes.Flee))
            {
                Flee.Execute();
            }


            PermaActive.Execute();
        }

        public static void Initialize()
        {
        }
    }
}