using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_029 : SimTemplate //Fallen Hero
    {

        //Your Hero Power deals 1 extra damage.

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnBuccaneer++;
            }
            else
            {
                p.anzEnemyBuccaneer++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnBuccaneer--;
            }
            else
            {
                p.anzEnemyBuccaneer--;
            }
        }

       

    }
}