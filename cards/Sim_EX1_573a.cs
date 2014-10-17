using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_573a : SimTemplate //demigodsfavor
	{

//    verleiht euren anderen dienern +2/+2.


		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                p.minionGetBuffed(m, 2, 2);
            }
		}

	}
}