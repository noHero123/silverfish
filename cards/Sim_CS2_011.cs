using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_011 : SimTemplate //savageroar
	{

//    verleiht euren charakteren +2 angriff in diesem zug.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            for (int i = 0; i < temp.Count; i++)
            {
                p.minionGetTempBuff(temp[i], 2, 0);
            }
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }
		}

	}
}