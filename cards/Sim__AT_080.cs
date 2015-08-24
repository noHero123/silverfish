using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_080 : SimTemplate //Garrison Commander
    {

        //You can use your Hero Power twice a turn.

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnGarrisonCommander+=1;
            }
            else
            {
                p.anzEnemyGarrisonCommander+=1;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnGarrisonCommander -= 1;
            }
            else
            {
                p.anzEnemyGarrisonCommander -= 1;
            }
        }

       

    }
}