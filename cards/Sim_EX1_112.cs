using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_112 : SimTemplate //gelbinmekkatorque
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka1);//homingchicken
//    kampfschrei:/ konstruiert eine fantastische erfindung.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own, true);
		}


	}
}