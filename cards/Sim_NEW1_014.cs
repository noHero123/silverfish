using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_014 : SimTemplate //masterofdisguise
	{

//    kampfschrei:/ verleiht einem befreundeten diener verstohlenheit/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.stealth = true;
		}


	}
}