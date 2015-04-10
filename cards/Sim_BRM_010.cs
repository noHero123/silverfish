using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_BRM_010 : SimTemplate //druidoftheclaw
	{

        //    Choose One - Transform into a 5/2 minion; or a 2/5 minion.
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);//5/2 minion
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t2);//2/5 minion.
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