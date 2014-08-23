using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_013 : SimTemplate //kelthuzad
	{

//    ruft am ende jedes zuges alle befreundeten diener herbei, die in diesem zug gestorben sind.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            foreach (GraveYardItem m in p.diedMinions.ToArray()) // toArray() because a knifejuggler could kill a minion due to the summon :D
            {
                if (triggerEffectMinion.own == m.own)
                {
                    CardDB.Card card = CardDB.Instance.getCardDataFromID(m.cardid);
                    p.callKid(card, p.ownMinions.Count, m.own);
                }
            }
        }

	}

}