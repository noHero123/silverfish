using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_012 : SimTemplate //sludgebelcher
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_012t);
//    spott.\ntodesröcheln:/ ruft einen schleim (1/2) mit spott/ herbei.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            
            p.callKid(c, m.zonepos - 1, m.own);
        }

	}
}