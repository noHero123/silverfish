using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_028 : SimTemplate //Trade Prince Gallywix
    {

        //    Whenever your opponent casts a spell, gain a copy of it and give them a Coin.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (c.type == CardDB.cardtype.SPELL && c.name != CardDB.cardName.gallywixscoin && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(c.cardIDenum, triggerEffectMinion.own, true);
                p.drawACard(CardDB.cardIDEnum.GVG_028t, wasOwnCard, true);
            }
        }


    }

}