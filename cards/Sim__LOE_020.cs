using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_020 : SimTemplate //desert camel
	{
        //bc: put a 1-cost minion from each deck into the battlefield

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168);//murloc raider

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                p.callKid(kid, p.ownMinions.Count, true);   
                p.callKid(kid, p.enemyMinions.Count, false);
                return;
            }


            if (Probabilitymaker.Instance.hasDeck)
            {
                //todo: summon a minion from your deck!
                p.callKid(kid, p.ownMinions.Count, true);   
            }
            else
            {
                p.callKid(kid, p.ownMinions.Count, true);   
            }
            p.callKid(kid, p.enemyMinions.Count, false);
        }

	}

}
