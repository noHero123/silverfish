using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_003 : SimTemplate //Fallen Hero
    {

        //Your Hero Power deals 1 extra damage.

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnFallenHeros++;
            }
            else
            {
                p.anzEnemyFallenHeros++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.anzOwnFallenHeros--;
            }
            else
            {
                p.anzEnemyFallenHeros--;
            }
        }

       

    }
}