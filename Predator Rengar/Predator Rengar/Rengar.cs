using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Enumerations;
using SharpDX;
using color = System.Drawing.Color;

namespace Predator_Rengar
{
    class Rengar
    {
        public static Obj_AI_Base leapTarget = null;
        public static int lastLeap = 0;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Validate Champion
            if (Player.Instance.Hero != Champion.Rengar) return;

            // Initialize Classes
            MenuDesigner.Initialize();
            ModeController.Initialize();

            // Events
            Game.OnUpdate += OnUpdate;
            Drawing.OnDraw += OnDraw;
            Orbwalker.OnPreAttack += OnPreAttack;
            Dash.OnDash += OnDash;
            Orbwalker.OnPostAttack += OnPostAttack;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
        }

        private static void OnUpdate(EventArgs args)
        {
            if (Return.HaveFullFerocity && Player.Instance.HealthPercent <= Return.AutoHealPercent && Spells.W.IsReady())
                Spells.W.Cast();

            if (Return.UseWSteal && Spells.W.IsReady())
            {
                foreach (var hero in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.W.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if (Player.Instance.GetSpellDamage(hero, SpellSlot.W) > hero.TotalShieldHealth() + 15)
                    {
                        Spells.W.Cast();
                    }
                }
            }

            if (Return.UseESteal && Spells.E.IsReady())
            {
                foreach (var hero in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.E.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if (Player.Instance.GetSpellDamage(hero, SpellSlot.E) > hero.TotalShieldHealth() + 15)
                    {
                        Spells.E.Cast(hero.ServerPosition);
                    }
                }
            }
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            if (Return.DrawComboMode)
            {
                var textPos = Drawing.WorldToScreen(Player.Instance.Position);
                Drawing.DrawText(textPos.X - 30, textPos.Y + 35, color.OrangeRed, Return.OneShotActive ? "One Shot [Q first]" : "Normal [E first]");
            }
        }

        private static void OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (ModeController.OrbCombo && args.Target is Obj_AI_Base && Return.UseQCombo)
            {
                leapTarget = args.Target as Obj_AI_Base;

                if (Environment.TickCount - lastLeap < 100 && !Return.HaveFullFerocity)
                {
                    if (Spells.Q.IsReady())
                        Spells.Q.Cast();
                    else
                        args.Process = false;

                    lastLeap = 0;
                }

                if (Spells.Q.IsReady() || Return.HaveFullFerocity)
                {
                    float dmg = 0f;

                    if (Return.HaveFullFerocity)
                        dmg = (float)Player.Instance.CalculateDamageOnUnit(leapTarget, DamageType.Physical, new int[] { 30, 45, 60, 75, 90, 105, 120, 135, 150, 160, 170, 180, 190, 200, 210, 220, 230, 240 }[Player.Instance.Level - 1] + (Player.Instance.BaseAttackDamage + Player.Instance.FlatPhysicalDamageMod) * 0.5f);
                    else
                        dmg = (float)Player.Instance.CalculateDamageOnUnit(leapTarget, DamageType.Physical, new int[] { 30, 60, 90, 120, 150 }[Spells.Q.Level - 1] + (Player.Instance.BaseAttackDamage + Player.Instance.FlatPhysicalDamageMod) * new int[] { 0, 5, 10, 15, 20 }[Spells.Q.Level - 1] / 100f);

                    if (dmg >= leapTarget.Health || (Return.WillLeap && Return.OneShotActive))
                    {
                        Spells.Q.Cast();
                        if (!Return.WillLeap)
                            args.Process = false;
                    }
                }

                if (Player.Instance.HasBuff("RengarR"))
                {
                    if (Item.HasItem(3142) && Item.CanUseItem(3142) && Return.UseItemYoumuus)
                        Item.UseItem(3142);
                }
            }
        }

        private static void OnDash(Obj_AI_Base sender, Dash.DashEventArgs args)
        {
            if (Orbwalker.DisableMovement)
                Orbwalker.DisableMovement = false;

            if (sender.IsMe && ModeController.OrbCombo && leapTarget != null)
            {
                if (leapTarget != null && leapTarget.IsValidTarget() && Return.UseECombo && Spells.E.IsReady() && (!Return.HaveFullFerocity || !Return.OneShotActive || !Player.Instance.HasBuff("rengarqbase") || Player.Instance.HasBuff("rengarqemp")))
                {
                    var pred = Spells.E.GetPrediction(leapTarget);

                    if (pred.HitChance > HitChance.Immobile)
                        Spells.E.Cast(pred.CastPosition);
                    else
                        Spells.E.Cast((leapTarget as Obj_AI_Base).ServerPosition);
                }

                if (Return.UseWCombo)
                    Spells.W.Cast();
            }
        }

        private static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (ModeController.OrbCombo)
            {
                if (Spells.Q.IsReady() && Return.UseQCombo)
                    Spells.Q.Cast();

                if (Item.HasItem(3077) && Item.CanUseItem(3077) && Return.UseItemTiamat)
                    Item.UseItem(3077);
                if (Item.HasItem(3074) && Item.CanUseItem(3074) && Return.UseItemHydra)
                    Item.UseItem(3074);
                if (Item.HasItem(3748) && Item.CanUseItem(3748) && Return.UseItemTitanic)
                    Item.UseItem(3748);
            }
            else if (ModeController.OrbLaneClear)
            {
                if (!target.IsDead && Return.UseQClear && (!Return.ClearSaveFerocity || !Return.HaveFullFerocity))
                {
                    Spells.Q.Cast();

                    if (Item.HasItem(3077) && Item.CanUseItem(3077) && Return.UseItemTiamat)
                        Item.UseItem(3077);
                    if (Item.HasItem(3074) && Item.CanUseItem(3074) && Return.UseItemHydra)
                        Item.UseItem(3074);
                    if (Item.HasItem(3748) && Item.CanUseItem(3748) && Return.UseItemTitanic)
                        Item.UseItem(3748);
                }
            }
        }

        private static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Return.InterruptE && Return.HaveFullFerocity && Spells.E.IsReady())
            {
                if (sender.IsValidTarget(Spells.E.Range))
                {
                    Spells.E.Cast(sender.ServerPosition);
                }
            }
        }
    }
}
