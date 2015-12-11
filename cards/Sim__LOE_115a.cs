using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_115a : SimTemplate //raven idol
	{
        //discover a minion

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            //TODO: make a difference :D

            if (p.isServer)
            {
                p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
                return;
            }

            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);

        }


	}

}
