using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_089 : SimTemplate //Boneguard Lieutenant
    {

        //Inspire: Gain +1 Health.

        public override void onInspire(Playfield p, Minion m)
        {
            p.minionGetBuffed(m, 0, 1);
        }


    }
}