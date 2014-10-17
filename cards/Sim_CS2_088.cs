using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_088 : SimTemplate //guardianofkings
    {

        //    kampfschrei:/ stellt bei eurem helden 6 leben wieder her.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);

            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
        }


    }
}