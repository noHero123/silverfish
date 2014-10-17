using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_144 : SimTemplate //shadowstep
	{

//    lasst einen befreundeten diener auf eure hand zurückkehren. der diener kostet (2) weniger.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionReturnToHand(target, ownplay, target.handcard.card.cost - 2);
		}

	}
}