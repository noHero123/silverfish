using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_017 : SimTemplate //shapeshift
	{

//    heldenfähigkeit/\n+1 angriff in diesem zug.\n+1 rüstung.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 1, 0);
                p.minionGetArmor(p.ownHero,1);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 1, 0);
                p.minionGetArmor(p.enemyHero,1);
            }
        }

	}
}