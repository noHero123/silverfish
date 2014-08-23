using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_tk33 : SimTemplate //inferno
	{

//    heldenfähigkeit/\nbeschwört eine höllenbestie (6/6).
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_tk34);//infernal

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int posi = (ownplay)? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, posi, ownplay);
		}

	}
}