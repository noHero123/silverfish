using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_623 : SimTemplate //templeenforcer
	{

//    kampfschrei:/ verleiht einem befreundeten diener +3 leben.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetBuffed(target, 0, 3);
		}

	}
}