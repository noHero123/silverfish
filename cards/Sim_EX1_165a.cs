using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_165a : SimTemplate //catform
	{

//    ansturm/
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_165t1);
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionTransform(own, cat);
            
        }

	}
}