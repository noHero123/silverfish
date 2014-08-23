using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_FP1_006 : SimTemplate //deathcharger
	{

//    ansturm. todesröcheln:/ fügt eurem helden 3 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.minionGetDamageOrHeal(p.ownHero, 3);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 3);
            }
        }

	}
}