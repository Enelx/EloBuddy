using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using color = System.Drawing.Color;


namespace Big_Brother
{
    class BigBrother
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
            Loading.OnLoadingCompleteSpectatorMode += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            MenuDesigner.Initialize();

            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            float gapPos = 0;

            foreach (var enemy in EntityManager.Heroes.Enemies)
            {
                if (Return.SpyEnable)
                {
                    gapPos += 15;
                    Drawing.DrawText(Return.SpyXpos, Return.SpyYpos + gapPos, color.White, enemy.ChampionName);

                    if (Return.SpyHealth)
                    {
                        if (enemy.HealthPercent > 0)
                            Drawing.DrawText(Return.SpyXpos + 100, Return.SpyYpos + gapPos, color.GreenYellow, "L " + (int)enemy.HealthPercent + "%");
                        else
                            Drawing.DrawText(Return.SpyXpos + 100, Return.SpyYpos + gapPos, color.Yellow, "L Rip");
                    }

                    if (Return.SpyFlash)
                    {
                        var FlashSlot = enemy.Spellbook.Spells[4];

                        if (FlashSlot.Name != "summonerflash")
                            FlashSlot = enemy.Spellbook.Spells[5];

                        if (FlashSlot.Name == "summonerflash")
                        {
                            var FlashTime = FlashSlot.CooldownExpires - Game.Time;

                            if (FlashTime < 0)
                                Drawing.DrawText(Return.SpyXpos + 160, Return.SpyYpos + gapPos, color.GreenYellow, "F rdy");
                            else
                                Drawing.DrawText(Return.SpyXpos + 160, Return.SpyYpos + gapPos, color.Yellow, "F " + (int)FlashTime);
                        }
                    }

                    if (Return.SpyUltimate)
                    {
                        if (enemy.Level >= 6)
                        {
                            var Rslot = enemy.Spellbook.Spells[3];
                            var Rtime = Rslot.CooldownExpires - Game.Time;

                            if (Rtime < 0)
                                Drawing.DrawText(Return.SpyXpos + 205, Return.SpyYpos + gapPos, color.GreenYellow, "R rdy");
                            else
                                Drawing.DrawText(Return.SpyXpos + 205, Return.SpyYpos + gapPos, color.Yellow, "R " + (int)Rtime);
                        }
                        else
                            Drawing.DrawText(Return.SpyXpos + 205, Return.SpyYpos + gapPos, color.Yellow, "R /");
                    }
                }
            }
        }
    }
}
