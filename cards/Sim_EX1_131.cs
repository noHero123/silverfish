using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_131 : SimTemplate //defiasringleader
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_131t);
//    combo:/ ruft einen banditen der defias (2/1) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1)
            {
                p.callKid(card, own.zonepos, own.own);
            }
		}


	}
}