using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_110t : SimTemplate //Boom Bot
    {

        //  Deathrattle: Deal 1-4 damage to a random enemy.

        

        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            if (temp.Count >= 1 && temp.Count >=1 )
            {
                p.minionGetDamageOrHeal(p.searchRandomMinion(temp, Playfield.searchmode.searchHighestHP), 2);
            }
            else
            {
                p.minionGetDamageOrHeal(((m.own)?p.enemyHero : p.ownHero), 2);
            }

        }


    }

}