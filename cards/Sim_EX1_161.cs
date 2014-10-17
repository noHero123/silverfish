using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_161 : SimTemplate //naturalize
	{

//    vernichtet einen diener. euer gegner zieht 2 karten.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
            p.drawACard(CardDB.cardName.unknown, !ownplay);
            p.drawACard(CardDB.cardName.unknown, !ownplay);
		}

	}
}