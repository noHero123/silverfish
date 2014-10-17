using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_150 : SimTemplate //stormpikecommando
	{

//    kampfschrei:/ verursacht 2 schaden.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetDamageOrHeal(target, 2);
		}


	}
}