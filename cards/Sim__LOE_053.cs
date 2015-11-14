using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_053 : SimTemplate //Djinni of Zephyrs
	{

        //    Whenever you cast a spell on another friendly minion, cast a copy of it on this one.
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (target != null && target.own == wasOwnCard && triggerEffectMinion.own == wasOwnCard && target.entitiyID != triggerEffectMinion.entitiyID && c.type == CardDB.cardtype.SPELL)
            {
                c.sim_card.onCardPlay(p, wasOwnCard, triggerEffectMinion, choice);
                p.doDmgTriggers();
            }
        }

	}
}