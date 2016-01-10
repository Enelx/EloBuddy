using System;
using System.Drawing;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Auto_Black_Spear
{
    class Program
    {
        public static Menu Menu;
        public static Item BlackSpear;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += On_Loading_Complete;
        }

        private static void On_Loading_Complete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Kalista") return;

            BlackSpear = new Item(ItemId.The_Black_Spear);

            Menu = MainMenu.AddMenu("Auto-Black-Spear", "AutoBlackSpear");
            Menu.Add("TrueBlack", new CheckBox("Activate Auto Black Spear"));

            Core.DelayAction(TheBlackSpear, 1000);

            Game.OnUpdate += On_Update;
        }

        private static void TheBlackSpear()
        {
            if (Menu["TrueBlack"].Cast<CheckBox>().CurrentValue && BlackSpear.IsOwned() && Player.Instance.IsInShopRange())
            {
                foreach (AIHeroClient ally in EntityManager.Heroes.Allies)
                {
                    if (ally != null)
                    {
                        BlackSpear.Cast(ally);
                    }
                }
            }
        }

        private static void On_Update(EventArgs args)
        {
            TheBlackSpear();
        }
    }
}
