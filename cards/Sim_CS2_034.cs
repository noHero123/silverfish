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
            p.minionGetDamageOrHeal(target, 1);
        }

	}
}