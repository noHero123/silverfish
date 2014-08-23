using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_355 : SimTemplate //blessedchampion
	{

//    verdoppelt den angriff eines dieners.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, target.Angr, 0);
		}

	}
}