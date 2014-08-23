using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1h_292 : SimTemplate //steadyshot
	{

//    heldenfähigkeit/\nfügt dem feindlichen helden 2 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
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