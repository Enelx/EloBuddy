using System;
using EloBuddy;
using EloBuddy.SDK;

namespace Smart_Potion
{
    internal class Potions
    {
        public static Item HealthPotion = new Item(ItemId.Health_Potion);
        public static Item Biscuit = new Item(ItemId.Total_Biscuit_of_Rejuvenation);
        public static Item HuntersPotion = new Item(ItemId.Hunters_Potion);
        public static Item CorruptingPotion = new Item(ItemId.Corrupting_Potion);
        public static Item RefillablePotion = new Item(ItemId.Refillable_Potion);

        internal static void Initialize()
        {
            Game.OnTick += OnTick;
        }

        private static void OnTick(EventArgs args)
        {
            if (Player.Instance.IsDead || Player.Instance.IsRecalling() || Player.Instance.IsInShopRange()) return;

            if (Player.Instance.Health + 250 > Player.Instance.MaxHealth) return;

            if (Player.Instance.HealthPercent > 50 && Player.Instance.CountEnemiesInRange(700) == 0) return;

            if (Player.HasBuff("RegenerationPotion") || Player.HasBuff("ItemMiniRegenPotion") ||
                Player.HasBuff("ItemCrystalFlaskJungle") || Player.HasBuff("ItemDarkCrystalFlask") ||
                Player.HasBuff("ItemCrystalFlask")) return;

            if (HealthPotion.IsReady())
                HealthPotion.Cast();
            else if (Biscuit.IsReady())
                Biscuit.Cast();
            else if (HuntersPotion.IsReady())
                HuntersPotion.Cast();
            else if (CorruptingPotion.IsReady())
                CorruptingPotion.Cast();
            else if (RefillablePotion.IsReady())
                RefillablePotion.Cast();
        }
    }
}