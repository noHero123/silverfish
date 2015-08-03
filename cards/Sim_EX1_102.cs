using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_102 : SimTemplate //demolisher
    {

        //    fügt zu beginn eures zuges einem zufälligen feind 2 schaden zu.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {

                if (p.isServer)
                {
                    Minion choosen = p.getRandomMinionFromSide_SERVER(!triggerEffectMinion.own, true);
                    if (choosen != null) p.minionGetDamageOrHeal( choosen, 2);
                    return;
                }

                List<Minion> temp2 = (turnStartOfOwner) ? p.enemyMinions : p.ownMinions;
                bool dmgdone = false;
                foreach (Minion mins in temp2)
                {
                    p.minionGetDamageOrHeal(mins, 2);
                    dmgdone = true;
                    break;
                }
                if (!dmgdone)
                {
                    p.minionGetDamageOrHeal(turnStartOfOwner ? p.enemyHero : p.ownHero, 2);
                };
            }
        }

    }
}