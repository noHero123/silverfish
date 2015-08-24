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
            int dmg = 2;

            if (ownplay)
            {
                dmg += p.anzOwnFallenHeros;
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
                p.minionGetDamageOrHeal(target, dmg);
            }
            else
            {
                dmg += p.anzEnemyFallenHeros;
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
                p.minionGetDamageOrHeal(target, dmg);
            }

		}

	}
}