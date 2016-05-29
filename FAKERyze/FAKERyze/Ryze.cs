using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using FAKERyze.Base;
using SharpDX;

namespace FAKERyze
{
    internal class Ryze
    {
        public static Spell.Skillshot Q = new Spell.Skillshot(SpellSlot.Q, 900, SkillShotType.Linear, 250, 1700, 60);
        public static Spell.Targeted W = new Spell.Targeted(SpellSlot.W, 600);
        public static Spell.Targeted E = new Spell.Targeted(SpellSlot.E, 600);
        public static Spell.Active R = new Spell.Active(SpellSlot.R);

        internal static void Initialize()
        {
            MenuDesigner.Initialize();
            ModeController.Initialize();

            Drawing.OnDraw += OnDraw;
            Orbwalker.OnPreAttack += OnPreAttack;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapcloser;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead || Shop.IsOpen || !Q.IsReady() || !MenuDesigner.ConfigUi.Get<CheckBox>("DrawQ").CurrentValue) return;

            Circle.Draw(Color.MediumBlue, Q.Range, Player.Instance);
        }

        private static void OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)) return;

            if (Q.IsReady() && target.IsValidTarget(Q.Range) && !target.IsZombie)
            {
                Q.Cast(target.Position);
            }
        }

        private static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy || e.DangerLevel != DangerLevel.High || !W.IsReady() || !W.IsInRange(sender)) return;

            W.Cast(sender);
        }

        private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy || !W.IsReady() || !W.IsInRange(e.End)) return;

            W.Cast(sender);
        }
    }
}