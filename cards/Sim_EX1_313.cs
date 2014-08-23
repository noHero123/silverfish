using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_313 : SimTemplate //pitlord
	{

//    kampfschrei:/ fügt eurem helden 5 schaden zu.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.minionGetDamageOrHeal(p.ownHero, 5);
            }
            else
            {
                p.minionGetDamageOrHeal(p.enemyHero, 5);
            }
		}


	}
}