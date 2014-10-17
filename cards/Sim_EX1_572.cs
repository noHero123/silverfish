using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_572 : SimTemplate //ysera
	{

//    zieht am ende eures zuges eine traumkarte.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.cardName.yseraawakens, turnEndOfOwner, true);
            }
        }

	}
}