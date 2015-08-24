using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_085 : SimTemplate //Maiden of the Lake
    {

        //Your Hero Power costs (1).

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnMaidenOfTheLake++;
            }
            else
            {
                p.anzEnemyMaidenOfTheLake++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnMaidenOfTheLake--;
            }
            else
            {
                p.anzEnemyMaidenOfTheLake--;
            }
        }



    }

}