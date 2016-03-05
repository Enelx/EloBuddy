using System;
using Broken_Blade_Riven.Assistants;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace Broken_Blade_Riven
{
    public class Riven
    {
        public delegate void DOnAnimationCastable(string animation);

        public static int QStacks;
        public static event DOnAnimationCastable OnAnimationCastable;

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
            Obj_AI_Base.OnPlayAnimation += OnPlayAnimation;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapcloser;
        }

        private static void OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (!sender.IsMe) return;
            var t = 0;
            switch (args.Animation)
            {
                // Q1
                case "Spell1a":
                    QStacks = 1;
                    t = 291;
                    break;
                // Q2
                case "Spell1b":
                    QStacks = 2;
                    t = 291;
                    break;
                // Q3
                case "Spell1c":
                    QStacks = 0;
                    t = 393;
                    break;
                // W
                case "Spell2":
                    t = 10;
                    break;
                // E
                case "Spell3":
                    break;
                // R1
                case "Spell4a":
                    break;
                // R2
                case "Spell4b":
                    t = 150;
                    break;
                default:
                    t = -1;
                    break;
            }
            if (t > 0)
            {
                if (!Return.Activemode(Orbwalker.ActiveModes.None))
                    Core.DelayAction(() => AnimationCancel(args.Animation), Math.Max(1, t - Game.Ping));
            }
            else if (t != -1)
                Core.DelayAction(() => { if (OnAnimationCastable != null) OnAnimationCastable(args.Animation); }, 1);
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

                if (ModeController.QStacks == 2 && sender.IsValidTarget(Spells.Q.Range))
                {
                    Spells.Q.Cast(sender.ServerPosition);
                }
            }
        }

        private static void AnimationCancel(string animation)
        {
            Orbwalker.ResetAutoAttack();
            Player.DoEmote(Emote.Laugh);

            if (animation == "Spell2" || animation == "Spell1c")
            {
                Player.IssueOrder(GameObjectOrder.MoveTo,
                    Player.Instance.ServerPosition.Shorten(Game.CursorPos,
                        Player.Instance.Distance(Game.CursorPos) + 10));
            }

            if (!Return.Activemode(Orbwalker.ActiveModes.None))
            {
                if (OnAnimationCastable != null) OnAnimationCastable(animation);
            }
        }
    }
}