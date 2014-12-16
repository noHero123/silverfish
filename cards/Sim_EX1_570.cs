using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_570 : SimTemplate //bite
	{

//    verleiht eurem helden +4 angriff in diesem zug und 4 rüstung.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 4, 0);
                p.minionGetArmor(p.ownHero, 4);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 4, 0);
                p.minionGetArmor(p.enemyHero, 4);

            }
		}

	}
}