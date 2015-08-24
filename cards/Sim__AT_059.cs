using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_059 : SimTemplate //Brave Archer
    {

        //insprire: If your hand is empty, deal 2 damage to the enemy hero.

        public override void onInspire(Playfield p, Minion m)
        {
            if (m.own && p.owncards.Count == 0)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 2);
            }
            if (!m.own && p.enemyAnzCards == 0)
            {
                p.minionGetDamageOrHeal(p.ownHero, 2);
            }
        }



    }

}