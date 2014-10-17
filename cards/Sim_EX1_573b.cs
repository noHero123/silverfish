using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_573b : SimTemplate //shandoslesson
	{

//    ruft zwei treants (2/2) mit spott/ herbei.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); //special treant
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, true);
            p.callKid(kid, pos, ownplay, true);
		}

	}
}