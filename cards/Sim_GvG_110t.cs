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
            if (p.isServer)
            {
                int randdmg = p.getRandomNumber_SERVER(1, 4);
                Minion poortarget = p.getRandomMinionFromSide_SERVER(!m.own, true);
                if (poortarget != null) p.minionGetDamageOrHeal(poortarget, randdmg);
                return;
            }

            int dmg = (m.own ? 2 : 3);
            p.doDmgToRandomEnemyCLIENT2(dmg, true, m.own);

        }


    }

}