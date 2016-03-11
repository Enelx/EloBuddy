using System;
using System.Linq;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Broken_Blade_Riven
{
    public class Riven
    {
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Validate Champion
            if (Player.Instance.Hero != Champion.Riven) return;

            // Initialize Classes
            MenuDesigner.Initialize();
            ModeController.Initialize();
            Spells.Initialize();

            // Events
            Orbwalker.OnPostAttack += OnPostAttack;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapcloser;
        }

        private static void OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!target.IsEnemy || target.IsZombie) return;

            if (Return.Activemode(Orbwalker.ActiveModes.Combo) ||
                Return.Activemode(Orbwalker.ActiveModes.Harass) ||
                Return.Activemode(Orbwalker.ActiveModes.JungleClear))
            {
                if (Spells.Q.IsReady())
                {
                    Spells.Q.Cast(target.Position);
                }

                if (Items.Tiamat.IsReady())
                {
                    Items.Tiamat.Cast();
                }
                else if (Items.Hydra.IsReady())
                {
                    Items.Hydra.Cast();
                }
            }
        }

        private static void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (Return.Activemode(Orbwalker.ActiveModes.None)) return;

            if (sender.IsMe && args.SData.Name == Spells.Q.Name)
            {
                if (Return.Activemode(Orbwalker.ActiveModes.Combo) ||
                    Return.Activemode(Orbwalker.ActiveModes.Harass))
                {
                    var target = TargetSelector.GetTarget(Spells.Q.Range, DamageType.Physical);

                    Player.DoEmote(Emote.Joke);
                    Player.IssueOrder(GameObjectOrder.MoveTo, sender);
                    Player.IssueOrder(GameObjectOrder.AutoAttack, target);
                }
                else if (Return.Activemode(Orbwalker.ActiveModes.JungleClear))
                {
                    var monster = Logic.Monsters(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

                    Player.DoEmote(Emote.Joke);
                    Player.IssueOrder(GameObjectOrder.MoveTo, sender);
                    Player.IssueOrder(GameObjectOrder.AutoAttack, monster);
                }
            }
        }

        private static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (sender.IsEnemy && sender.IsValidTarget(Spells.W.Range) && Spells.W.IsReady())
            {
                Spells.W.Cast();
            }
        }

        private static void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (Return.UseGapclose && sender.IsEnemy)
            {
                if (Spells.W.IsReady() && e.End.Distance(Player.Instance.ServerPosition) <= Spells.W.Range)
                {
                    Core.DelayAction(() => Spells.W.Cast(), 100 + Game.Ping);
                }
            }
        }
    }
}