using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_165b : SimTemplate //bearform
	{

//    +2 leben und spott/.
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t2);
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
                p.minionTransform(own, bear);
        }

	}
}