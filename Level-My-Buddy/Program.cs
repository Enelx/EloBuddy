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

namespace Level_My_Buddy
{
    public static class Program
    {
        private static Menu Config;
        public static int lvl1, lvl2, lvl3, lvl4, minValue, maxValue;

        static void Main(string[] args)
        {
            Game.OnLoad += GameOnLoad;
        }

        private static void GameOnLoad(EventArgs args)
        {
            Config = MainMenu.AddMenu("Level My Buddy", "LvlMyBuddy");
            Config.Add("AutoLvl", new CheckBox("Enable", true));
            StringList(Config, "1", "1", new[] { "Q", "W", "E", "R" }, 3);
            StringList(Config, "2", "2", new[] { "Q", "W", "E", "R" }, 1);
            StringList(Config, "3", "3", new[] { "Q", "W", "E", "R" }, 1);
            StringList(Config, "4", "4", new[] { "Q", "W", "E", "R" }, 1);
            Config.Add("LvlStart", new Slider("Auto start at LvL:", 2, 1, 6));
            Config.Add("MinDelay", new Slider("Minimum Delay:", 500, 1, 1500));
            Config.Add("MaxDelax", new Slider("Maximum Delay:", 1000, 2, 3000));

            Game.OnUpdate += GameOnUpdate;
            Obj_AI_Base.OnLevelUp += OnLevelUp;
        }

        private static bool Getcheckboxvalue(Menu menu, string menuvalue)
        {
            return menu[menuvalue].Cast<CheckBox>().CurrentValue;
        }

        private static int Getslidervalue(Menu menu, string menuvalue)
        {
            return menu[menuvalue].Cast<Slider>().CurrentValue;
        }

        public static void StringList(this Menu m, string uniqueId, string displayName, string[] values, int defaultValue)
        {
            var mode = m.Add(uniqueId, new Slider(displayName, defaultValue, 0, values.Length - 1));
            mode.DisplayName = displayName + ": " + values[mode.CurrentValue];
            mode.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
            {
                sender.DisplayName = displayName + ": " + values[args.NewValue];
            };
        }

        private static void GameOnUpdate(EventArgs args)
        {
            lvl1 = Getslidervalue(Config, "1");
            lvl2 = Getslidervalue(Config, "2");
            lvl3 = Getslidervalue(Config, "3");
            lvl4 = Getslidervalue(Config, "4");
        }

        private static void up(int indx)
        {
            if (Player.Instance.Level < 4)
            {
                if (indx == 0 && Player.Instance.Spellbook.GetSpell(SpellSlot.Q).Level == 0)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.Q);
                if (indx == 1 && Player.Instance.Spellbook.GetSpell(SpellSlot.W).Level == 0)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.W);
                if (indx == 2 && Player.Instance.Spellbook.GetSpell(SpellSlot.E).Level == 0)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.E);
            }
            else
            {
                if (indx == 0)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.Q);
                if (indx == 1)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.W);
                if (indx == 2)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.E);
                if (indx == 3)
                    Player.Instance.Spellbook.LevelSpell(SpellSlot.R);
            }
        }

        private static void OnLevelUp(Obj_AI_Base sender, Obj_AI_BaseLevelUpEventArgs args)
        {
            if (!sender.IsMe || !Getcheckboxvalue(Config, "AutoLvl") || Player.Instance.Level < Getslidervalue(Config, "LvlStart"))
                return;
            if (lvl2 == lvl3 || lvl2 == lvl4 || lvl3 == lvl4)
                return;

            minValue = Getslidervalue(Config, "MinDelay");
            maxValue = Getslidervalue(Config, "MaxDelay");

            Random rnd = new Random();
            var random = rnd.Next(minValue, maxValue);

            Core.DelayAction(() => up(lvl1), random);
            Core.DelayAction(() => up(lvl2), random);
            Core.DelayAction(() => up(lvl3), random);
            Core.DelayAction(() => up(lvl4), random);
        }
    }
}
