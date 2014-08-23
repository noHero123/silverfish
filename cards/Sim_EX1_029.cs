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
            if (m.own)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 2);
            }
            else
            {
                p.minionGetDamageOrHeal(p.ownHero, 2);
            }
        }

	}
}