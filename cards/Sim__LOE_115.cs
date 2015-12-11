using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_115 : SimTemplate //raven idol
	{
        //Choose one: discover a minion, or discover a spell

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
