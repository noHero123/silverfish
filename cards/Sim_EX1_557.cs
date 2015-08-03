using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_557 : SimTemplate //natpagle
	{

//    zu beginn eures zuges besteht eine chance von 50%, dass ihr eine zusätzliche karte zieht.
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (p.isServer)
                {
                    int random = p.getRandomNumber_SERVER(0, 1);
                    if (random == 0)
                    {
                        p.drawACard(CardDB.cardIDEnum.None, turnStartOfOwner);
                    }
                    return;
                }
                p.drawACard(CardDB.cardIDEnum.None, turnStartOfOwner);
            }
        }

	}
}