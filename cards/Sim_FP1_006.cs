using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_FP1_006 : SimTemplate //deathcharger
    {

        //    ansturm. todesröcheln:/ fügt eurem helden 3 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, 3);
        }

    }
}