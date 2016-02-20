using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Enumerations;


namespace Tsar_Corki.Modes
{
    public static class Flee
    {
        public static bool ShouldBeExecuted()
        {
            return ModeController.OrbFlee;
        }

        public static void Execute()
        {
            var curSpot = Player.Instance.Position.Extend(Game.CursorPos, 1000);

            if (Spells.W.IsReady())
            {
                Player.CastSpell(SpellSlot.W, curSpot.To3D());
            }
        }
    }
}
