using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_039 : SimTemplate //Dalaran Aspirant
    {

        //insprire: gain Spell Damage +1

        public override void onInspire(Playfield p, Minion m)
        {
            p.minionGetTempBuff((m.own) ? p.ownHero : p.enemyHero, 2, 0);
        }



    }

}