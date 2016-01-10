using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Ping_My_Buddy
{
    class Program
    {
        public static int LastPing;
        public static int NumberOfPings;
        public static Menu Config;
        public static Random Rnd = new Random(Environment.TickCount);

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += On_Loading_Complete;
        }

        private static void On_Loading_Complete(EventArgs args)
        {
            Config = MainMenu.AddMenu("Ping My Buddy", "PingMyBuddy");
            Config.Add("maxpings", new Slider("Max Pings at once", 2, 1, 6));
            Config.Add("pingtarget", new CheckBox("Ping Focus Target", false));
            Config.Add("pinghelp", new CheckBox("Ping for Help"));
            Config.Add("pingdanger", new CheckBox("Ping in Danger"));
            Config.Add("pinggank", new CheckBox("Ping Gank Warning"));

            Game.OnUpdate += On_Update;
        }

        private static void On_Update(EventArgs args)
        {
            if (Environment.TickCount - LastPing > Rnd.Next(10000, 60000))
                NumberOfPings = 0;

            if (Config["pingtarget"].Cast<CheckBox>().CurrentValue && Player.Instance.CountEnemiesInRange(1000) <= Player.Instance.CountAlliesInRange(1000))
            {
                PingTarget(ObjectManager.Get<AIHeroClient>().Where(h => h.IsEnemy && h.IsValidTarget() && h.Distance(Player.Instance) < 1000).OrderBy(TargetSelector.GetPriority).ThenBy(e => e.Health).FirstOrDefault());
                return;
            }

            if (Player.Instance.CountEnemiesInRange(1000) > Player.Instance.CountAlliesInRange(1000))
            {
                if (Config["pinghelp"].Cast<CheckBox>().CurrentValue && Player.Instance.CountAlliesInRange(2500) >= Player.Instance.CountEnemiesInRange(1000))
                {
                    PingGround(GetPointNearMe(800), PingCategory.AssistMe);
                    return;
                }
                if (Config["pingdanger"].Cast<CheckBox>().CurrentValue)
                    PingGround(GetPointNearMe(800), PingCategory.Danger);
            }
        }

        private static Vector3 GetPointNearMe(int range)
        {
            var circle = new Geometry.Polygon.Circle(Player.Instance.ServerPosition.To2D(), range).ToClipperPath();
            var point = circle.OrderBy(p => Rnd.Next()).FirstOrDefault();
            return new Vector2(point.X, point.Y).To3D();
        }

        private static void PingTarget(Obj_AI_Base target)
        {
            if (!target.IsValidTarget(1000)) return;
            if (Environment.TickCount - LastPing < Rnd.Next(100, 1100) || NumberOfPings >= Rnd.Next(Math.Max(1, Config["maxpings"].Cast<Slider>().CurrentValue / 2), Config["maxpings"].Cast<Slider>().CurrentValue)) return;
            LastPing = Environment.TickCount;
            NumberOfPings++;
            TacticalMap.SendPing(PingCategory.Normal, target);
        }

        private static void PingGround(Vector3 point, PingCategory pingtype)
        {
            if (point.Distance(Player.Instance.ServerPosition) > 1000) return;
            if (Environment.TickCount - LastPing < Rnd.Next(100, 1100) || NumberOfPings >= Rnd.Next(Math.Max(1, Config["maxpings"].Cast<Slider>().CurrentValue / 2), Config["maxpings"].Cast<Slider>().CurrentValue)) return;
            LastPing = Environment.TickCount;
            NumberOfPings++;
            TacticalMap.SendPing(pingtype, point);
        }
    }
}
