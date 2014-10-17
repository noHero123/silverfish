using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_104 : SimTemplate //rampage
	{

//    verleiht einem verletzten diener +3/+3.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 3, 3);
		}

	}
}