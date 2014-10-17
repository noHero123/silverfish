using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_164b : SimTemplate //nourish
	{

//    zieht 3 karten.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
		}

	}
}