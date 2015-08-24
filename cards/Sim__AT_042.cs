using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_042 : SimTemplate //Druid of the Saber
	{

        //    Choose One - Transform to gain Charge or +1/+1 and Stealth
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t);//charge
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t2);//1/1 stealth
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