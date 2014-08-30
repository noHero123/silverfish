using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_Mekka1 : SimTemplate //homingchicken
	{

//    vernichtet zu beginn eures zuges diesen diener und zieht 3 karten.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
                p.drawACard(CardDB.cardName.unknown, turnStartOfOwner);
            }
        }

	}
}