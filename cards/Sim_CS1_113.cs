using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS1_113 : SimTemplate //mindcontrol
	{

//    übernehmt die kontrolle über einen feindlichen diener.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetControlled(target, ownplay, false);
		}

	}
}