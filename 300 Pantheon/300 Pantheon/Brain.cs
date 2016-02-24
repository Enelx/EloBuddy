using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using _300_Pantheon.Assistants;

namespace _300_Pantheon
{
    public class Brain
    {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Validate Champion
            if (Player.Instance.Hero != Champion.Pantheon) return;

            // Initialize Classes
            MenuDesigner.Initialize();
            ModeController.Initialize();

            //  Events
            Obj_AI_Base.OnProcessSpellCast += Pantheon.OnProcessSpellCast;
            Obj_AI_Base.OnBuffLose += Pantheon.OnBuffLose;
            Orbwalker.OnPostAttack += Pantheon.OnPostAttack;
            Interrupter.OnInterruptableSpell += Pantheon.OnInterruptableSpell;
            Gapcloser.OnGapcloser += Pantheon.OnGapcloser;
            Drawing.OnDraw += Pantheon.OnDraw;
        }
    }
}
