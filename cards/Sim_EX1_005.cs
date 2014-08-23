using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_005 : SimTemplate //biggamehunter
	{

//    kampfschrei:/ vernichtet einen diener mit mind. 7 angriff.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target != null) p.minionGetDestroyed(target);
		}


	}
}