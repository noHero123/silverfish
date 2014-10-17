using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_549 : SimTemplate //bestialwrath
	{

//    verleiht einem wildtier +2 angriff und immunität/ in diesem zug.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetTempBuff(target, 2, 0);
            target.immune = true;
		}

	}
}