using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_063t : SimTemplate //Dreadscale
    {

        //Whenever another minion takes damage, destroy it
        //destroying done in triggerAMinionGotDmg
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.entitiyID != triggerEffectMinion.entitiyID) p.minionGetDamageOrHeal(m, 1);
                }

                foreach (Minion m in p.enemyMinions)
                {
                    if (m.entitiyID != triggerEffectMinion.entitiyID) p.minionGetDamageOrHeal(m, 1);
                }
            }
        }

       

    }
}