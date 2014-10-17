using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_101 : SimTemplate //reinforce
	{

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit

//    heldenfähigkeit/\nruft einen rekruten der silbernen hand (1/1) herbei.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, posi, ownplay);
        }

	}
}