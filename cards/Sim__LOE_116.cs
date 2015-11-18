using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_116 : SimTemplate //reliquary seeker
	{
        //bcry: If you have 6 other minions, gain +4/+4.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownMinions.Count == 6)
                {
                    p.minionGetBuffed(own, 4, 4);
                }
            }
            else
            {
                if (p.enemyMinions.Count == 6)
                {
                    p.minionGetBuffed(own, 4, 4);
                }
            }
        }
        

	}

}
