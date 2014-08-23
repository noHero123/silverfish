using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_110 : SimTemplate //cairnebloodhoof
	{

//    todesröcheln:/ ruft baine bluthuf (4/5) herbei.
        CardDB.Card blaine = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_110t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(blaine, m.zonepos-1, m.own);
        }

	}
}