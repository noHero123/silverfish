using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_050 : SimTemplate //coldlightoracle
	{

//    kampfschrei:/ jeder spieler zieht 2 karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, true);
            p.drawACard(CardDB.cardName.unknown, true);
            p.drawACard(CardDB.cardName.unknown, false);
            p.drawACard(CardDB.cardName.unknown, false);

		}


	}
}