using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_034 : SimTemplate //fireblast
	{

//    heldenfähigkeit/\nverursacht 1 schaden.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 1;
            if (ownplay)
            {
                if (p.doublepriest >= 1) dmg *= (2 * p.doublepriest);
            }
            else
            {
                if (p.enemydoublepriest >= 1) dmg *= (2 * p.enemydoublepriest);
            }
            p.minionGetDamageOrHeal(target, dmg);
        }

	}
}