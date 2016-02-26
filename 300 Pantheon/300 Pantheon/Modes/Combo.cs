using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using _300_Pantheon.Assistants;

namespace _300_Pantheon.Modes
{
    public static class Combo
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Combo);
        }

        public static void Execute()
        {
            var target = Logic.CloseEnemies(Spells.Q.Range, Player.Instance.ServerPosition).FirstOrDefault();

            if (target == null || !target.IsValidTarget(Spells.Q.Range)) return;

            if (Return.UseAgressiveItems)
                Items.CastItems(target);

            if (Return.UseQCombo && Spells.Q.IsReady())
                Spells.Q.Cast(target);
            else if (Return.UseWCombo && Spells.W.IsReady())
                Spells.W.Cast(target);
            else if (Return.UseECombo && Spells.E.IsReady())
            {
                var pred = Spells.E.GetPrediction(target);

                Spells.E.Cast(pred.CastPosition);
            }
        }
    }
}