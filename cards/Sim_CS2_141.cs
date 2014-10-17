using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_141 : SimTemplate //ironforgerifleman
	{

//    kampfschrei:/ verursacht 1 schaden.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 1;
            p.minionGetDamageOrHeal(target, dmg);
		}


	}
}