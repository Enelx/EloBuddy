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
    internal class Pantheon
    {
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
            var buff = "pantheonesound";
            if (sender.IsMe && args.Buff.Name == buff)
            {
                Orbwalker.DisableAttacking = false;
                Orbwalker.DisableMovement = false;
            }
        }
        
        public static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (Return.UseAgressiveItems && ModeController.OrbCombo)
            {
                Items.Useitems(target, 400);
            }
        }

        public static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (sender.IsMe || sender.IsAlly || sender.IsUnderEnemyturret()) return;

            if (Return.UseWGapclose && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
            {
                Spells.W.Cast(sender);
            }
        }

        public static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Return.UseWInterrupt && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
            {
                Spells.W.Cast(sender);
            }
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