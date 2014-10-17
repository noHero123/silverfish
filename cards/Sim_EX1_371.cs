using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_371 : SimTemplate //handofprotection
	{

//    verleiht einem diener gottesschild/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.divineshild = true;
		}

	}
}