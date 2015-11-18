using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_248 : SimTemplate //feralspirit
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk11);//spiritwolf
//    ruft zwei geisterwölfe (2/3) mit spott/ herbei. überladung:/ (2)

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
            p.changeRecall(ownplay, 2);

		}

	}
}