using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_077 : SimTemplate //Anima Golem
    {

        //  At the end of each turn, destroy this minion if it's your only one. 

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own)
            {
                if (p.ownMinions.Count == 1)
                {
                    p.minionGetDestroyed(triggerEffectMinion);
                }
            }
            else
            {
                if (p.enemyMinions.Count == 1)
                {
                    p.minionGetDestroyed(triggerEffectMinion);
                }
            }
        }


    }

}