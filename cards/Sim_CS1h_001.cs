using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS1h_001 : SimTemplate //lesserheal
	{

//    heldenfähigkeit/\nstellt 2 leben wieder her.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(2) : p.getEnemySpellHeal(2);
            p.minionGetDamageOrHeal(target, -heal);
            
            
		}

	}
}