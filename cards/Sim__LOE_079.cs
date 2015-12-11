using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_079 : SimTemplate //elise starseeker
	{
        //bc: shuffle the map of the golden monkey into your deck

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.isServer)
            {
                if (own.own)
                {
                    p.ownDeckSize++;
                }
                else
                {
                    p.enemyDeckSize++;
                }
                return;
            }

            if (own.own)
            {
                p.ownDeckSize++;
            }
            else
            {
                p.enemyDeckSize++;
            }
            
        }

	}

}
