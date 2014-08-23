using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_236 : SimTemplate //divinespirit
	{

//    verdoppelt das leben eines dieners.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 0, target.Hp);
		}

	}
}