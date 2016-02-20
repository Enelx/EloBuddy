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

namespace Tsar_Corki
{
    class Corki
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Validate Champion
            if (Player.Instance.Hero != Champion.Corki) return;

            // Initialize Classes
            MenuDesigner.Initialize();
            ModeController.Initialize();

            // Events
            Game.OnUpdate += OnUpdate;
            Gapcloser.OnGapcloser += OnGapcloser;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnUpdate(EventArgs args)
        {
            if (Return.UseRKs)
            {
                if (!Spells.R.IsReady() || Spells.R.Handle.Ammo == 0)
                    return;

                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.R.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if ((Player.Instance.GetSpellDamage(target, SpellSlot.R)) > target.TotalShieldHealth() + 10)
                    {
                        Spells.R.Cast(target.ServerPosition);
                    }
                }
            }

            if (Return.UseQKs)
            {
                if (!Spells.Q.IsReady())
                    return;

                foreach (AIHeroClient target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Spells.Q.Range) && !x.HasBuffOfType(BuffType.Invulnerability)))
                {
                    if ((Player.Instance.GetSpellDamage(target, SpellSlot.Q)) > target.TotalShieldHealth() + 10)
                        Spells.Q.Cast(target.ServerPosition);
                }
            }
        }

        private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Return.UseWGapclose && sender.IsEnemy)
            {
                var pred = e.End;

                if (Spells.W.IsReady())
                {
                    Spells.W.Cast(pred + 5 * (Player.Instance.ServerPosition - e.End));
                }
            }
        }

        private static void OnDraw(EventArgs args)
        {
            if (Return.DrawQRange && Spells.Q.IsReady())
            {
                Circle.Draw(Color.Aqua, Spells.Q.Range, 1, Player.Instance.Position);
            }

            if (Return.DrawRRange && Spells.R.IsReady())
            {
                Circle.Draw(Color.AntiqueWhite, Spells.R.Range, 1, Player.Instance.Position);
            }
        }
    }
}
