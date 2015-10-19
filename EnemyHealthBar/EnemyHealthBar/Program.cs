using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using Color1 = System.Drawing.Color;

namespace EnemyHealthBar
{
    class Program
    {
        private static Menu menu;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            menu = MainMenu.AddMenu("Enemy Health Bar", "enemyhealthbar");
            menu.AddGroupLabel("Enemy Health Bar");
            menu.AddSeparator();
            menu.AddLabel("Enelx @ EloBuddy");
            menu.AddSeparator();
            menu.Add("enemyhealthsupp", new CheckBox("Enable Enemy Health Bar", true));

            Drawing.OnDraw += On_Draw;
        }

        private static void On_Draw(EventArgs args)
        {
            if (!enemyhealthsupp)
                return;

            foreach (var enemy in EntityManager.Heroes.Enemies.Where(h => h.IsHPBarRendered))
            {
                var barPosition = enemy.HPBarPosition;
                var x = barPosition.X;
                var y = barPosition.Y;
                var h2 = Math.Round(enemy.Health, 0).ToString();

                Drawing.DrawText(x - 45, y + 15, Color1.White, h2.ToString(), 5);
            }
        }

        public static bool enemyhealthsupp
        {
            get { return menu.Get<CheckBox>("enemyhealthsupp").CurrentValue; }
        }
    }
}
