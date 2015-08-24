using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_110 : SimTemplate //Argent Watchman
    {

        //insprire: Can attack as normal this turn.

        public override void onInspire(Playfield p, Minion m)
        {
            p.minionReturnToHand(m, m.own, 0);
        }



    }

}