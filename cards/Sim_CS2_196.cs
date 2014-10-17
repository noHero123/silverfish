using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_196 : SimTemplate //razorfenhunter
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_boar);//boar
//    kampfschrei:/ ruft einen eber (1/1) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
           
            p.callKid(kid, own.zonepos, own.own, true);
		}

	}
}