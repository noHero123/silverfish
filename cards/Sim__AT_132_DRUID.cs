using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_132_DRUID : SimTemplate //shapeshift
	{

        //    Gain 2 Armor and +2 Attack this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetTempBuff(p.ownHero, 2, 0);
                p.minionGetArmor(p.ownHero,2);
            }
            else
            {
                p.minionGetTempBuff(p.enemyHero, 2, 0);
                p.minionGetArmor(p.enemyHero,2);
            }
        }

	}
}