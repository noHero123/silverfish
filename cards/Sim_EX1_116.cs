using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_116 : SimTemplate //leeroyjenkins
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_116t);//whelp
//    ansturm/. kampfschrei:/ ruft zwei welplinge (1/1) für euren gegner herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{

            int pos = (own.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(kid, pos, !own.own);
            p.callKid(kid, pos, !own.own);
		}
	}
}