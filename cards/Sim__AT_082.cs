using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_082 : SimTemplate //Lowly Squire
    {

        //Inspire: Gain +1 Attack.

        public override void onInspire(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 1, 0);
        }


    }
}