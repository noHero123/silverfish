using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_109 : SimTemplate //Argent Watchman
    {

        //insprire: Can attack as normal this turn.

        public override void onInspire(Playfield p, Minion m)
        {
            m.canAttackNormal = true;
            m.updateReadyness();
        }



    }

}