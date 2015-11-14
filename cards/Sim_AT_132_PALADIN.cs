using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_PALADIN : SimTemplate //reinforce
	{

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit

        //    Summon two 1/1 Recruits.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
        }

	}
}