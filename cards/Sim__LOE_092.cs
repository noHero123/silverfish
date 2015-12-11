using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_092 : SimTemplate //arch-thief-rafaam
	{
        //bc: discover a powerful artifact.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                p.drawACard(CardDB.cardIDEnum.LOEA16_4, own.own, true);
                return;
            }
            //TODO add a choice card with all 3 artifacts?
            p.drawACard(CardDB.cardIDEnum.LOEA16_4, own.own, true);
        }

	}

}
