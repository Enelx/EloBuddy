using EloBuddy;
using EloBuddy.SDK;

namespace FAKERyze.Modes
{
    internal class Combo
    {
        public static void Execute()
        {
            var etarget = TargetSelector.GetTarget(Ryze.E.Range, DamageType.Magical);
            var qtarget = TargetSelector.GetTarget(Ryze.Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(Ryze.W.Range, DamageType.Magical);

            if (Player.Instance.GetBuffCount("ryzepassivestack") < 1)
            {
                if (Ryze.Q.IsReady())
                {
                    if (qtarget == null || qtarget.IsInvulnerable) return;
                    Ryze.Q.Cast(qtarget);
                }
                else if (Ryze.E.IsReady())
                {
                    if (etarget == null || etarget.IsInvulnerable) return;
                    Ryze.E.Cast(etarget);
                }
                else if (Ryze.W.IsReady())
                {
                    if (wtarget == null || wtarget.IsInvulnerable) return;
                    Ryze.W.Cast(wtarget);
                }
            }
            else
            {
                if (Player.Instance.Level < 6)
                {
                    if (Player.Instance.GetBuffCount("ryzepassivestack") <= 2)
                    {
                        if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                    else if (Player.Instance.GetBuffCount("ryzepassivestack") == 3)
                    {
                        if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                    else if (Player.Instance.GetBuffCount("ryzepassivestack") == 4 ||
                             Player.Instance.GetBuff("RyzePassiveCharged") != null)
                    {
                        if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                }
                else if (Player.Instance.Level >= 6)
                {
                    if (Player.Instance.GetBuffCount("ryzepassivestack") == 1)
                    {
                        if (Ryze.R.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.R.Cast();
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                    else if (Player.Instance.GetBuffCount("ryzepassivestack") == 2)
                    {
                        if (Ryze.R.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.R.Cast();
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                    else if (Player.Instance.GetBuffCount("ryzepassivestack") == 3)
                    {
                        if (Ryze.Q.IsOnCooldown || Player.Instance.HealthPercent <= 30)
                        {
                            if (Ryze.R.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.R.Cast();
                            }
                            else if (Ryze.W.IsReady())
                            {
                                if (wtarget == null || wtarget.IsInvulnerable) return;
                                Ryze.W.Cast(wtarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.E.IsReady())
                            {
                                if (etarget == null || etarget.IsInvulnerable) return;
                                Ryze.E.Cast(etarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.W.IsReady())
                            {
                                if (wtarget == null || wtarget.IsInvulnerable) return;
                                Ryze.W.Cast(wtarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.E.IsReady())
                            {
                                if (etarget == null || etarget.IsInvulnerable) return;
                                Ryze.E.Cast(etarget);
                            }
                        }
                        else
                        {
                            if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.W.IsReady())
                            {
                                if (wtarget == null || wtarget.IsInvulnerable) return;
                                Ryze.W.Cast(wtarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.E.IsReady())
                            {
                                if (etarget == null || etarget.IsInvulnerable) return;
                                Ryze.E.Cast(etarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.W.IsReady())
                            {
                                if (wtarget == null || wtarget.IsInvulnerable) return;
                                Ryze.W.Cast(wtarget);
                            }
                            else if (Ryze.Q.IsReady())
                            {
                                if (qtarget == null || qtarget.IsInvulnerable) return;
                                Ryze.Q.Cast(qtarget);
                            }
                            else if (Ryze.E.IsReady())
                            {
                                if (etarget == null || etarget.IsInvulnerable) return;
                                Ryze.E.Cast(etarget);
                            }
                        }
                    }
                    else if (Player.Instance.GetBuffCount("ryzepassivestack") == 4 ||
                             Player.Instance.GetBuff("RyzePassiveCharged") != null)
                    {
                        if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.W.IsReady())
                        {
                            if (wtarget == null || wtarget.IsInvulnerable) return;
                            Ryze.W.Cast(wtarget);
                        }
                        else if (Ryze.Q.IsReady())
                        {
                            if (qtarget == null || qtarget.IsInvulnerable) return;
                            Ryze.Q.Cast(qtarget);
                        }
                        else if (Ryze.E.IsReady())
                        {
                            if (etarget == null || etarget.IsInvulnerable) return;
                            Ryze.E.Cast(etarget);
                        }
                    }
                }
            }
        }
    }
}