using System;
using Black_Swan_Akali.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace Black_Swan_Akali
{
    public class Akali
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.Hero != Champion.Akali) return;

            // Initialize Classes
            MenuDesigner.Initialize();
            ModeController.Initialize();

            // Events
            Orbwalker.OnPostAttack += OnPostAttack;
            Gapcloser.OnGapcloser += OnGapcloser;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Return.Activemode(Orbwalker.ActiveModes.Combo) ||
                Return.Activemode(Orbwalker.ActiveModes.Harass) ||
                Return.Activemode(Orbwalker.ActiveModes.JungleClear))
            {
                if (Spells.E.IsReady() && Return.UseECombo)
                {
                    Spells.E.Cast();
                }
            }
        }

        private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy || sender.IsUnderEnemyturret()) return;

            if (Return.UseRGapclose && Spells.R.IsReady() && sender.IsValidTarget(Spells.R.Range))
            {
                Spells.R.Cast(sender);
            }
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead || Shop.IsOpen || MainMenu.IsOpen) return;

            var color = new ColorBGRA(255, 255, 255, 100);

            if (Return.DrawQRange && Spells.Q.IsReady())
            {
                Circle.Draw(color, Spells.Q.Range, Player.Instance.Position);
            }

            if (Return.DrawRRange && Spells.R.IsReady())
            {
                Circle.Draw(color, Spells.R.Range, Player.Instance.Position);
            }
        }
    }
}