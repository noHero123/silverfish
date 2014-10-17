using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_165 : SimTemplate //druidoftheclaw
	{

//    wählt aus:/ ansturm/; oder +2 leben und spott/.
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1)
            {
                p.minionTransform(own, cat);
            }
            if (choice == 2)
            {
                p.minionTransform(own, bear);
            }
		}


	}
}