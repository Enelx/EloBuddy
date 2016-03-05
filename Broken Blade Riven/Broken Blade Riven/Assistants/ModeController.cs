using System;
using Broken_Blade_Riven.Modes;
using Broken_Blade_Riven.Modes.Combo;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Broken_Blade_Riven.Assistants
{
    public static class ModeController
    {
        public delegate void DOnAnimationCastable(string animation);

        public static int Mode = 1, T, QStacks;
        public static bool Q3Casted;

        static ModeController()
        {
            Game.OnTick += OnTick;
        }

        public static event DOnAnimationCastable OnAnimationCastable;

        public static void ModeSwitch(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
        {
            if (args.NewValue)
            {
                switch (Mode)
                {
                    case 1:
                        Mode = 2;
                        Chat.Print("Combo Mode changed to: " + Mode + " Flash");
                        break;
                    case 2:
                        Mode = 3;
                        Chat.Print("Combo Mode changed to: " + Mode + " Range");
                        break;
                    case 3:
                        Mode = 4;
                        Chat.Print("Combo Mode changed to: " + Mode + " Burst");
                        break;
                    case 4:
                        Mode = 1;
                        Chat.Print("Combo Mode changed to: " + Mode + " Generic");
                        break;
                }
            }
        }

        private static void OnTick(EventArgs args)
        {
            if (Return.Activemode(Orbwalker.ActiveModes.Combo))
            {
                switch (Mode)
                {
                    case 1:
                        Generic.Execute();
                        break;
                    case 2:
                        Flash.Execute();
                        break;
                    case 3:
                        Range.Execute();
                        break;
                    case 4:
                        Burst.Execute();
                        break;
                }
            }
            else if (Return.Activemode(Orbwalker.ActiveModes.Flee))
            {
                Flee.Execute();
            }
            else if (Return.Activemode(Orbwalker.ActiveModes.LaneClear))
            {
                Clear.Execute();
            }
            if (Return.Activemode(Orbwalker.ActiveModes.JungleClear))
            {
                Jungle.Execute();
            }
        }

        public static void Initialize()
        {
        }
    }
}