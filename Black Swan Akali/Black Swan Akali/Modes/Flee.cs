using Black_Swan_Akali.Assistants;
using EloBuddy.SDK;

namespace Black_Swan_Akali.Modes
{
    public static class Flee
    {
        public static bool ShouldBeExecuted()
        {
            return Return.Activemode(Orbwalker.ActiveModes.Flee);
        }

        public static void Execute()
        {
            if (Return.UseWFlee && Spells.W.IsReady())
            {
                Spells.W.Cast();
            }
        }
    }
}