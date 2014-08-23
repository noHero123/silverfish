using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_625t : SimTemplate //mindspike
	{

//    heldenfähigkeit/\nverursacht 2 schaden.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDamageOrHeal(target, 2);
		}

	}
}