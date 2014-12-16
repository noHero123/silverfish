using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_111 : SimTemplate //Mimiron's Head
    {

        //   At the start of your turn, if you have at least 3 Mechs, destroy them all and form V-07-TR-0N.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_111t);

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if(turnStartOfOwner != triggerEffectMinion.own) return;
            List<Minion> temp = (turnStartOfOwner) ? p.ownMinions : p.enemyMinions;
            int anz =0;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL && m.Hp >=1 )
                {
                    anz++;
                }
            }
            if (anz >= 3)
            {
                foreach (Minion m in temp)
                {
                    if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                    {
                        p.minionGetDestroyed(m);
                    }
                }

                int pos = (triggerEffectMinion.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, triggerEffectMinion.own,false, true); // we allow to summon one minion more (because 3 are destroyed)
            }
        }

    }

}