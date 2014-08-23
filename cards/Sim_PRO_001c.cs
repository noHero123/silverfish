using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_PRO_001c : SimTemplate //powerofthehorde
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_390);
//    beschwört einen zufälligen krieger der horde.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, posi, ownplay);
		}

	}
}