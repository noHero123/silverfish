using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_PRIEST : SimTemplate //lesserheal
	{

        //    Restore #4 Health.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = 4;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest >= 1) heal = -heal;
                if (p.doublepriest >= 1) heal *= (2 * p.doublepriest);
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1) heal = -heal;
                if (p.enemydoublepriest >= 1) heal *= (2 * p.enemydoublepriest);
            }
            p.minionGetDamageOrHeal(target, -heal);
            
            
		}

	}
}