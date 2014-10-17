using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_151 : SimTemplate //silverhandknight
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_152);//squire
//    kampfschrei:/ ruft einen knappen (2/2) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own, true);
		}

	}
}