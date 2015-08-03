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

                if (p.isServer)
                {
                    int random = p.getRandomNumber_SERVER(0, 4);
                    if (random == 0) p.drawACard(CardDB.cardIDEnum.DREAM_01, turnEndOfOwner, true);
                    if (random == 1) p.drawACard(CardDB.cardIDEnum.DREAM_02, turnEndOfOwner, true);
                    if (random == 2) p.drawACard(CardDB.cardIDEnum.DREAM_03, turnEndOfOwner, true);
                    if (random == 3) p.drawACard(CardDB.cardIDEnum.DREAM_04, turnEndOfOwner, true);
                    if (random == 4) p.drawACard(CardDB.cardIDEnum.DREAM_05, turnEndOfOwner, true);
                }
                p.drawACard(CardDB.cardIDEnum.DREAM_02, turnEndOfOwner, true);
            }
        }

	}
}