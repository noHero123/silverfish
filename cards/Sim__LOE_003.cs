using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_003 : SimTemplate //ethereal conjurer
	{
        //Battlecry: discover a spell

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                p.drawACard(CardDB.cardIDEnum.None, own.own, true);
                return;
            }
            p.drawACard(CardDB.cardIDEnum.None, own.own, true);
        }

	}

}
