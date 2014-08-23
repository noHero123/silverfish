using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_562 : SimTemplate //onyxia
	{

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t);//whelp

//    kampfschrei:/ ruft welplinge (1/1) herbei, bis eure seite des schlachtfelds voll ist.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int kids = 7 - p.ownMinions.Count;
           
            for (int i = 0; i < kids; i++)
            {
                p.callKid(kid, own.zonepos, own.own, true);
            }

		}


	}
}