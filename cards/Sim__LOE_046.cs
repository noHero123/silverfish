using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOE_046 : SimTemplate //huge toad
    {

        //  Deathrattle: Deal 1 damage to a random enemy.

        

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.isServer)
            {
                int randdmg = 1;
                Minion poortarget = p.getRandomMinionFromSide_SERVER(!m.own, true);
                if (poortarget != null) p.minionGetDamageOrHeal(poortarget, randdmg);
                return;
            }

            p.doDmgToRandomEnemyCLIENT2(1, true, m.own);

        }


    }

}