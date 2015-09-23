using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_166a : SimTemplate //moonfire
	{

//    verursacht 2 schaden.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if(target!=null) p.minionGetDamageOrHeal(target, 2);
		}

	}
}