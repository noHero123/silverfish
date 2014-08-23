using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_382 : SimTemplate //aldorpeacekeeper
	{

//    kampfschrei:/ setzt den angriff eines feindlichen dieners auf 1.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null) p.minionSetAngrToOne(target);
		}

	}
}