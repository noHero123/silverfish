using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_091 : SimTemplate //Boneguard Lieutenant
    {

        //Inspire: Gain +1 Health.

        public override void onInspire(Playfield p, Minion m)
        {
            int heal = (m.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.minionGetDamageOrHeal(m.own ? p.ownHero : p.enemyHero, -heal);
        }


    }
}