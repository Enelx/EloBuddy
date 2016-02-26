using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Rendering;
using SharpDX;
using _300_Pantheon.Assistants;

namespace _300_Pantheon
{
    public class Pantheon
    {
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
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Obj_AI_Base.OnBuffLose += OnBuffLose;
            Orbwalker.OnPostAttack += OnPostAttack;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapcloser;
            Drawing.OnDraw += OnDraw;
        }

        public static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe && args.SData.Name == Spells.E.Name)
            {
                Orbwalker.DisableAttacking = true;
                Orbwalker.DisableMovement = true;
            }
        }

        public static void OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            const string buff = "pantheonesound";

            if (sender.IsMe && args.Buff.Name == buff)
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }
        }

        public static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Return.Activemode(Orbwalker.ActiveModes.Combo) && Return.UseAgressiveItems && target != null)
            {
                if (Items.Tiamat.IsOwned() && Items.Tiamat.IsReady() && target.IsValidTarget(Items.Tiamat.Range))
                    Items.Tiamat.Cast();
                else if (Items.Hydra.IsOwned() && Items.Hydra.IsReady() && target.IsValidTarget(Items.Hydra.Range))
                    Items.Tiamat.Cast();
            }
        }

        public static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy || sender.IsUnderEnemyturret()) return;

            if (Return.UseWGapclose && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
                Spells.W.Cast(sender);
        }

        public static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Return.UseWInterrupt && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
                Spells.W.Cast(sender);
        }

        public static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead || Shop.IsOpen || MainMenu.IsOpen) return;

            if (Return.DrawQweRange)
            {
                Circle.Draw(Color.Orange, Spells.Q.Range, 1, Player.Instance.Position);
            }
        }
    }
}