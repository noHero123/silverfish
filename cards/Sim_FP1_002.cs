using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_002 : SimTemplate //hauntedcreeper
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_002t);
//    todesröcheln:/ ruft zwei spektrale spinnen (1/1) herbei.
		

        public override void onDeathrattle(Playfield p, Minion m)
        {
            
            p.callKid(c, m.zonepos-1, m.own);
            p.callKid(c, m.zonepos-1, m.own);
        }

	}
}