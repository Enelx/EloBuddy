using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using FAKERyze.Base;

namespace FAKERyze.Modes
{
    internal class Harass
    {
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(Ryze.E.Range, DamageType.Magical);

            if (!target.IsValidTarget() || target == null || Player.Instance.GetBuffCount("ryzepassivestack") >= 4 ||
                !MenuDesigner.ConfigUi.Get<CheckBox>("HarassE").CurrentValue) return;

            if (Ryze.E.IsReady())
            {
                Ryze.E.Cast(target);
            }
        }
    }
}