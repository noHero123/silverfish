using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_008b : SimTemplate //ancientsecrets
	{

//    stellt 5 leben wieder her.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = (own.own) ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);
            p.minionGetDamageOrHeal(target, -heal);
		}

	}
}