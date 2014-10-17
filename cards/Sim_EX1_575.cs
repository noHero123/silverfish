using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_575 : SimTemplate //manatidetotem
	{

//    zieht am ende eures zuges eine karte.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.drawACard(CardDB.cardName.unknown, turnEndOfOwner);
            }
        }

	}
}