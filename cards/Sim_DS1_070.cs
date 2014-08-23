using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_070 : SimTemplate //houndmaster
	{

//    kampfschrei:/ verleiht einem befreundeten wildtier +2/+2 und spott/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetBuffed(target, 2, 2);
                target.taunt = true;
            }
		}


	}
}