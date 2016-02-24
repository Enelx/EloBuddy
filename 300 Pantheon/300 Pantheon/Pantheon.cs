using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace _300_Pantheon
{
    class Pantheon
    {
        static void Main(string[] args)
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
            Game.OnUpdate += OnUpdate;
            Orbwalker.OnPostAttack += OnPostAttack;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapcloser;
            Drawing.OnDraw += OnDraw;
        }
        private static void OnUpdate(EventArgs args)
        {
            if (Return.UseQKs)
            {
                if (!Spells.Q.IsReady()) return;

                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.Q.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if ((Player.Instance.GetSpellDamage(target, SpellSlot.Q)) > target.TotalShieldHealth() + 5)
                        Spells.Q.Cast(target);
                }
            }

            if (Return.UseWKs)
            {
                if (!Spells.W.IsReady()) return;

                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.W.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if ((Player.Instance.GetSpellDamage(target, SpellSlot.W)) > target.TotalShieldHealth())
                        Spells.W.Cast(target);
                }
            }
        }

        private static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (ModeController.OrbCombo)
            {
                if (Return.UseAgressiveItems && target != null)
                {
                    if (Items.Tiamat.IsReady() && target.IsValidTarget(Items.Tiamat.Range))
                        Items.Tiamat.Cast();
                    else if (Items.Hydra.IsReady() && target.IsValidTarget(Items.Hydra.Range))
                        Items.Hydra.Cast();
                }
            }
        }

        private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (Return.UseWGapclose && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady() && !sender.IsUnderEnemyturret())
                Spells.W.Cast(sender);
        }

        private static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Return.UseWInterrupt && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
                Spells.W.Cast(sender);
        }

        private static void OnDraw(EventArgs args)
        {
            if (Return.DrawQWERange && !Player.Instance.IsDead)
                Circle.Draw(Color.Orange, Spells.Q.Range, 1, Player.Instance.Position);
        }
    }
}
