using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AAsteering
{
    internal class Steering
    {
        private static Menu _aamenu;

        public static void Initialize()
        {
            Chat.Print("AAsteering loaded, by Enelx");

            _aamenu = MainMenu.AddMenu("AAsteering", "AAsteering");
            _aamenu.AddLabel("This only works, if your aa range is > target's aa range");
            _aamenu.Add("UseAA", new KeyBind("Enable AAsteering", true, KeyBind.BindTypes.PressToggle, 'T'));

            Game.OnTick += OnTick;
        }

        private static void OnTick(EventArgs args)
        {
            if (!_aamenu["UseAA"].Cast<KeyBind>().CurrentValue) return;

            foreach (
                var target in
                    EntityManager.Heroes.Enemies.Where(
                        target =>
                            target.IsValidTarget(Player.Instance.GetAutoAttackRange() + Player.Instance.BoundingRadius) &&
                            target.IsFacing(Player.Instance) && !target.IsFleeing))
            {
                var toTarget = target.ServerPosition - Player.Instance.ServerPosition;
                var distanceFromEach = toTarget.Length();
                var amountOfOverlap = Player.Instance.GetAutoAttackRange() + target.GetAutoAttackRange() -
                                      distanceFromEach;

                if (amountOfOverlap >= 0)
                {
                    Orbwalker.MoveTo(toTarget/distanceFromEach*amountOfOverlap);
                }
            }
        }
    }
}