using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_112 : SimTemplate //gelbinmekkatorque
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka1);//homingchicken
        CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka2);
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka3);
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4);
//    kampfschrei:/ konstruiert eine fantastische erfindung.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.isServer)
            {
                int random = p.getRandomNumber_SERVER(0, 3);
                if (random == 0) p.callKid(kid, own.zonepos, own.own, true);
                if (random == 1) p.callKid(kid1, own.zonepos, own.own, true);
                if (random == 2) p.callKid(kid2, own.zonepos, own.own, true);
                if (random == 3) p.callKid(kid3, own.zonepos, own.own, true);
                
                return;
            }
            p.callKid(kid, own.zonepos, own.own, true);
		}


	}
}