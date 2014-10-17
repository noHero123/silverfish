using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_059 : SimTemplate //crazedalchemist
	{

//    kampfschrei:/ vertauscht angriff und leben eines dieners.
        //todo: use buffs after that
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionSwapAngrAndHP(target);
		}

	}
}