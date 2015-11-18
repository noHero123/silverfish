using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_077 : SimTemplate //Brann bronzebeard
	{

        //    YourBattlecries trigger twice.


        public override void onAuraStarts(Playfield p, Minion own)
        {
            
            if (own.own)
            {
                p.anzOwnBranns++;
            }
            else
            {
                p.anzEnemyBranns++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnBranns--;
            }
            else
            {
                p.anzEnemyBranns--;
            }
        }
	}
}