using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_008a : SimTemplate //ancientteachings
	{

//    zieht 2 karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
            p.drawACard(CardDB.cardName.unknown, own.own);
		}
	}
}