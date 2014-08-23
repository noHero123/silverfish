using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_341 : SimTemplate//lightwell
    {

        // <deDE>Stellt zu Beginn Eures Zuges bei einem verletzten befreundeten Charakter 3 Leben wieder her.</deDE>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                List<Minion> temp = (turnStartOfOwner) ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    bool healed = false;
                    foreach (Minion mins in temp)
                    {
                        if (mins.wounded)
                        {
                            p.minionGetDamageOrHeal(mins, -3);
                            healed = true;
                            break;
                        }
                    }

                    if (!healed)
                    {
                        if (turnStartOfOwner) p.minionGetDamageOrHeal(p.ownHero, -3);
                        else p.minionGetDamageOrHeal(p.enemyHero, -3);
                    }
                }
                else
                {
                    if (turnStartOfOwner) p.minionGetDamageOrHeal(p.ownHero, -3);
                    else p.minionGetDamageOrHeal(p.enemyHero, -3);
                }

            }
        }
    }
}
