using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_306 : SimTemplate //succubus
	{

//    kampfschrei:/ werft eine zufällige karte ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{

            if (p.isServer)
            {
                p.discardRandomCard_SERVER(own.own);
                return;
            }

            p.disCardACard(own.own);
		}

	}
}