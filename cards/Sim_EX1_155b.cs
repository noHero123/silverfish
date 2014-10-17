using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_155b : SimTemplate //markofnature
	{

//    +4 leben und spott/.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 0, 4);
            target.taunt = true;
		}

	}
}