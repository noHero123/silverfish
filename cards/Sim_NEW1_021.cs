using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_021 : SimTemplate //doomsayer
	{

//    vernichtet zu beginn eures zuges alle diener.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner == triggerEffectMinion.own)
            {
                p.allMinionsGetDestroyed();
            }
        }

	}
}