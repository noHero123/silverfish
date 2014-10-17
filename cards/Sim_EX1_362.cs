using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_362 : SimTemplate //argentprotector
	{

//    kampfschrei:/ verleiht einem befreundeten diener gottesschild/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.divineshild = true;
		}

	}
}