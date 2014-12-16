using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_031 : SimTemplate //Recycle
    {

        //   Shuffle an enemy minion into your opponent's deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            bool own = ownplay;
            List<Minion> temp = (own) ? p.ownMinions : p.enemyMinions;
            target.handcard.card.sim_card.onAuraEnds(p, target);
            temp.Remove(target);

            if (own)
            {
                p.tempTrigger.ownMinionsChanged = true;
                p.ownDeckSize++;
            }
            else
            {
                p.tempTrigger.enemyMininsChanged = true;
                p.enemyDeckSize++;
            }
        }


    }

}