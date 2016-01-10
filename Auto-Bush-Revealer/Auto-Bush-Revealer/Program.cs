using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Auto_Bush_Revealer
{
    class Program
    {
        private static Menu Config;
        private static int lastWarded;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += On_Loading_Complete;
        }

        private static void On_Loading_Complete(EventArgs args)
        {
            Config = MainMenu.AddMenu("Auto Bush Revealer", "AutoBushRevealer");
            Config.Add("enable", new CheckBox("Enable Bush Revealer"));
            Config.Add("humanizeron", new CheckBox("Use Humanizer"));

            Game.OnUpdate += On_Update;
        }

        private static void On_Update(EventArgs args)
        {
            if (!Config["enable"].Cast<CheckBox>().CurrentValue) return;

            Random rnd = new Random();

            var random = Config["humanizeron"].Cast<CheckBox>().CurrentValue ? rnd.Next(200, 500) : 0;

            var combo = Orbwalker.ActiveModes.Combo;

            if (combo == null) return;

            foreach (var heros in EntityManager.Heroes.Enemies.Where(x => !x.IsDead && x.Distance(Player.Instance) < 1000))
            {
                var path = heros.Path.LastOrDefault();

                if (NavMesh.IsWallOfGrass(path, 1))
                {
                    if (heros.Distance(path) > 200) return;
                    if (NavMesh.IsWallOfGrass(Player.Instance.Position, 1) && Player.Instance.Distance(path) < 200) return;

                    if (Player.Instance.Distance(path) < 500)
                    {
                        foreach (var obj in ObjectManager.Get<AIHeroClient>().Where(x => x.Name.ToLower().Contains("ward") && x.IsAlly && x.Distance(path) < 300))
                        {
                            if (NavMesh.IsWallOfGrass(obj.Position, 1)) return;
                        }

                        var wardslot = GetWardSlot();
                        if (wardslot != null && Environment.TickCount - lastWarded > 1000)
                        {
                            Core.DelayAction(() => wardslot.Cast(path), random);
                            lastWarded = Environment.TickCount;
                        }
                    }
                }
            }

        }

        public static ItemId[] WardIds = {ItemId.Warding_Totem_Trinket, ItemId.Greater_Stealth_Totem_Trinket, ItemId.Greater_Vision_Totem_Trinket, ItemId.Sightstone, ItemId.Ruby_Sightstone, (ItemId) 2301, (ItemId)2302, (ItemId)2303,
                (ItemId) 3711, (ItemId) 1411, (ItemId) 1410, (ItemId) 1408, (ItemId) 1409};

        public static InventorySlot GetWardSlot()
        {
            return WardIds.Select(wardId => Player.Instance.InventoryItems.FirstOrDefault(a => a.Id == wardId)).FirstOrDefault(slot => slot != null && slot.CanUseItem());
        }
    }
}
