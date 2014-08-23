using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_573 : SimTemplate //cenarius
	{

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); //special treant
//    wählt aus:/ verleiht euren anderen dienern +2/+2; oder ruft zwei treants (2/2) mit spott/ herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1)
            {
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    p.minionGetBuffed(m, 2, 2);
                }
            }
            if (choice == 2)
            {

                int pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, own.own, true);
                p.callKid(kid, pos, own.own, true);
            }
		}

		

	}
}