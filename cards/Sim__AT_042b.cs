using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_042b : SimTemplate //bearform
	{

        //   choose 2/5 minion
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t2);
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
                p.minionTransform(own, bear);
        }

	}
}