using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Deus_Blitzcrank_Machina
{
    class Program
    {
        public const string ChampName = "Blitzcrank";
        public static Menu Config, Combofig, Miscfig, Drawfig, Skinfig;
        public static Spell.Skillshot Q;
        public static Spell.Active W, E, R;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComple;
        }

        private static void OnLoadingComple(EventArgs args)
        {
            if (Player.Instance.ChampionName != ChampName) return;

            Q = new Spell.Skillshot(SpellSlot.Q, (int)950f, SkillShotType.Linear, (int)0.25f, (int)1800f, (int)70f);
            W = new Spell.Active(SpellSlot.W, (int)700f);
            E = new Spell.Active(SpellSlot.E, (int)150f);
            R = new Spell.Active(SpellSlot.R, (int)540f);

            Config = MainMenu.AddMenu("Devine Blitz\nMachina", "DevineBlitzMachina");
            Config.AddGroupLabel("What a God of a Machine");
            Config.AddLabel("Made by - Enelx");

            Combofig = Config.AddSubMenu("Combo", "Combo");
            Combofig.Add("Combo_Q", new CheckBox("Use Q"));
            Combofig.Add("Combo_W", new CheckBox("Use W"));
            Combofig.Add("Combo_E", new CheckBox("Use E"));
            Combofig.Add("Combo_R", new CheckBox("Use R"));
            Combofig.AddSeparator();
            Combofig.Add("Range_R", new Slider("R -> Enemies in range", 1, 1, 5));

            Miscfig = Config.AddSubMenu("Misc", "Misc");
            Miscfig.AddGroupLabel("Interrupt Settings");
            Miscfig.Add("Inter_Q", new CheckBox("Use Q"));
            Miscfig.Add("Inter_E", new CheckBox("Use E"));
            Miscfig.Add("Inter_R", new CheckBox("Use R"));
            Miscfig.AddGroupLabel("Anti Gapcloser");
            Miscfig.Add("Gap_R", new CheckBox("Use R"));
            Miscfig.AddGroupLabel("Flee");
            Miscfig.Add("Flee_W", new CheckBox("Use W"));
            Miscfig.AddGroupLabel("Support");
            Miscfig.Add("Supp_Mode", new CheckBox("Supporter Mode", false));

            Drawfig = Config.AddSubMenu("Draw", "Draw");
            Drawfig.Add("Draw_Q", new CheckBox("Draw Q"));
            Drawfig.Add("Draw_R", new CheckBox("Draw R", false));

            Skinfig = Config.AddSubMenu("Skin", "Skin");
            Skinfig.AddGroupLabel("Select your Skin");

            var skin = Skinfig.Add("sID", new Slider("Skin", 8, 0, 8));
            var sID = new[] { "Classic", "Rusty", "Goalkeeper", "Boom Boom", "Piltover Customs", "Definitely Not", "iBlitzcrank", "Riot", "Battle Boss" };
            skin.DisplayName = sID[skin.CurrentValue];

            skin.OnValueChange +=
                delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
                {
                    sender.DisplayName = sID[changeArgs.NewValue];
                };

            Game.OnUpdate += OnUpdate;
            Game.OnTick += OnTick;
            Interrupter.OnInterruptableSpell += OnInterruptableSpell;
            Gapcloser.OnGapcloser += OnGapCloser;
            Orbwalker.OnPreAttack += OnPreAttack;
            Drawing.OnDraw += OnDraw;

            Chat.Print("<font color=\"#ffbd33\">DEUS BLITZCRANK MACHINA</font> - Made by - Enelx");
        }

        private static void OnUpdate(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            var QTarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var WTarget = TargetSelector.GetTarget(1500, DamageType.Physical);
            var RTarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            var combo = Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo;
            var flee = Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Flee;

            if (flee == true)
            {
                if (Miscfig["Flee_W"].Cast<CheckBox>().CurrentValue && W.IsReady())
                    W.Cast();
            }

            if (combo == false) return;

            if (Combofig["Combo_Q"].Cast<CheckBox>().CurrentValue && Q.IsReady() && QTarget != null)
            {
                Q.Cast(QTarget);
            }
            if (Combofig["Combo_W"].Cast<CheckBox>().CurrentValue && W.IsReady() && WTarget != null)
            {
                W.Cast();
            }
            if (Combofig["Combo_E"].Cast<CheckBox>().CurrentValue && E.IsReady() && QTarget.Distance(Player.Instance.ServerPosition) < 230)
            {
                E.Cast();
            }
            if (Player.Instance.CountEnemiesInRange(R.Range) >= Combofig["Range_R"].Cast<Slider>().CurrentValue && Combofig["Combo_R"].Cast<CheckBox>().CurrentValue && R.IsReady() && RTarget != null)
            {
                R.Cast();
            }
        }

        private static void OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (Miscfig["Inter_Q"].Cast<CheckBox>().CurrentValue && Q.IsReady())
            {
                if (sender.Distance(Player.Instance.ServerPosition, true) <= Q.RangeSquared)
                    Q.Cast(sender);
            }
            if (Miscfig["Inter_E"].Cast<CheckBox>().CurrentValue && E.IsReady())
            {
                if (sender.Distance(Player.Instance.ServerPosition, true) <= E.RangeSquared)
                    E.Cast();
            }
            if (Miscfig["Inter_R"].Cast<CheckBox>().CurrentValue && R.IsReady())
            {
                if (sender.Distance(Player.Instance.ServerPosition, true) <= R.RangeSquared)
                    R.Cast();
            }
        }

        private static void OnGapCloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (Miscfig["Gap_R"].Cast<CheckBox>().CurrentValue && sender.IsValidTarget(R.Range) && R.IsReady())
                R.Cast();
        }

        private static void OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) &&
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit) &&
                !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear)) return;   

            var t = target as Obj_AI_Minion;
            
            if (t == null) return;

            if (Miscfig["Supp_Mode"].Cast<CheckBox>().CurrentValue)
                args.Process = false;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead) return;

            if (Drawfig["Draw_Q"].Cast<CheckBox>().CurrentValue && Q.IsReady())
                Circle.Draw(Color.Aquamarine, Q.Range, Player.Instance.Position);
            if (Drawfig["Draw_R"].Cast<CheckBox>().CurrentValue && R.IsReady())
                Circle.Draw(Color.Beige, Q.Range, Player.Instance.Position);
        }

        private static void OnTick(EventArgs args)
        {
            SkinIDs();
        }

        private static void SkinIDs()
        {
            var style = Skinfig["sID"].DisplayName;

            switch (style)
            {
                case "Classic":
                    Player.SetSkinId(0);
                    break;
                case "Rusty":
                    Player.SetSkinId(1);
                    break;
                case "Goalkeeper":
                    Player.SetSkinId(2);
                    break;
                case "Boom Boom":
                    Player.SetSkinId(3);
                    break;
                case "Piltover Customs":
                    Player.SetSkinId(4);
                    break;
                case "Definitely Not":
                    Player.SetSkinId(5);
                    break;
                case "iBlitzcrank":
                    Player.SetSkinId(6);
                    break;
                case "Riot":
                    Player.SetSkinId(7);
                    break;
                case "Battle Boss":
                    Player.SetSkinId(8);
                    break;
            }
        }
    }
}
