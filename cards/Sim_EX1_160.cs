using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_160 : SimTemplate //powerofthewild
	{

//    wählt aus:/ verleiht euren dienern +1/+1; oder ruft einen panther (3/2) herbei.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t);//panther

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1)
            {
                List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    p.minionGetBuffed(m, 1, 1);
                }
            }
            if (choice == 2)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, posi, true);
                
            }
		}

	}
}