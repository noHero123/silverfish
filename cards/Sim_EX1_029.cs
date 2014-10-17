using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_029 : SimTemplate //lepergnome
    {

        //    todesröcheln:/ fügt dem feindlichen helden 2 schaden zu.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, 2);
        }

    }
}