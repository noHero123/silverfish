using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_FP1_001 : SimTemplate //zombiechow
    {

        //    todesröcheln:/ stellt beim feindlichen helden 5 leben wieder her.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);

            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, -heal);
        }

    }
}