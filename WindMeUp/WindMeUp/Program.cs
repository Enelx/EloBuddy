using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Color1 = System.Drawing.Color;

namespace WindMeUp
{
    class Program
    {
        public static double windup;
        private static Menu menu;


        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            menu = MainMenu.AddMenu("Wind Me Up", "windmeup");
            menu.AddGroupLabel("Wind Me Up");
            menu.AddSeparator();
            menu.AddLabel("Enelx @ EloBuddy");
            menu.AddSeparator();
            menu.Add("windupsupp", new CheckBox("Enable Windup Support", true));

            Drawing.OnDraw += On_Draw;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (windupsupp)
            {
                windup = Game.Ping * 1.5;
            }
        }

        private static void On_Draw(EventArgs args)
        {
            if (windupsupp)
            {
                Drawing.DrawText(Drawing.WorldToScreen(Player.Instance.Position) - new Vector2(30, -40), Color1.Cyan, "Perfect Windup Time is: " + windup, 2);
            }
        }

        public static bool windupsupp
        {
            get { return menu.Get<CheckBox>("windupsupp").CurrentValue; }
        }
    }
}
