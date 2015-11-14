using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_012 : SimTemplate //manawyrm
	{

//    erhält jedes mal +1 angriff, wenn ihr einen zauber wirkt.
        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                triggerEffectMinion.Angr++;
            }
        }
	}
}