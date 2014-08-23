using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_283 : SimTemplate //frostelemental
	{

//    kampfschrei:/ friert/ einen charakter ein.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            target.frozen = true;
		}


	}
}