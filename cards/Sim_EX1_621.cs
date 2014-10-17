using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_621 : SimTemplate //circleofhealing
	{

//    stellt bei allen dienern #4 leben wieder her.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(4) : p.getEnemySpellHeal(4);
            p.allMinionsGetDamage(-heal);
		}

	}
}