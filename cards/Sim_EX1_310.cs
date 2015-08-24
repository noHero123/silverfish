using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_310 : SimTemplate //doomguard
	{

//    ansturm/. kampfschrei:/ werft zwei zufällige karten ab.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{

            if (p.isServer)
            {
                p.discardRandomCard_SERVER(own.own);
                p.discardRandomCard_SERVER(own.own);
                return;
            }

            p.disCardACard(own.own);
            p.disCardACard(own.own);


		}

	}
}