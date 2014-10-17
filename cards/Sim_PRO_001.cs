using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_PRO_001 : SimTemplate //elitetaurenchieftain
	{

//    kampfschrei:/ verleiht beiden spielern die macht des rock! (durch eine powerakkordkarte)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.roguesdoit, true, true);
            p.drawACard(CardDB.cardName.roguesdoit, false, true);
		}

	}
}