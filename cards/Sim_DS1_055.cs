using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_055 : SimTemplate //darkscalehealer
	{

//    kampfschrei:/ stellt bei allen befreundeten charakteren 2 leben wieder her.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int heal = (own.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.allCharsOfASideGetDamage(own.own, -heal);
		}


	}
}