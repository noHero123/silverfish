using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_166b : SimTemplate //dispel
	{

//    bringt einen diener zum schweigen/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
                p.minionGetSilenced(target);
		}

	}
}