using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_571 : SimTemplate //forceofnature
	{

//    ruft drei treants (2/2) mit ansturm/ herbei, die am ende des zuges sterben.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk9);//Treant

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int posi =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
		}

	}
}