using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_111 : SimTemplate //Refreshment Vendor
    {

        //Battlecry: Restore 4 Health to each hero

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
           
            int heal2 = (own.own) ? p.getMinionHeal(4) : p.getEnemyMinionHeal(4);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal2);
            p.minionGetDamageOrHeal(own.own ? p.enemyHero : p.ownHero, -heal2);
        }

       

    }
}