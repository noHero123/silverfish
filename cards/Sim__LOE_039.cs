using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_039 : SimTemplate //gorillabot a-3
	{
        //Battlecry: if you control a mech, discover a mech

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                bool hasmech = false;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.handcard.card.race == TAG_RACE.MECHANICAL) hasmech = true;
                }
                if(hasmech) p.drawACard(CardDB.cardIDEnum.None, own.own, true);
            }
            else
            {
                bool hasmech = false;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.handcard.card.race == TAG_RACE.MECHANICAL) hasmech = true;
                }
                if (hasmech) p.drawACard(CardDB.cardIDEnum.None, own.own, true);
            }
        }

	}

}
