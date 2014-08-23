using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_126 : SimTemplate //betrayal
	{

//    zwingt einen feindlichen diener, seinen schaden benachbarten dienern zuzufügen.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            //attack right neightbor
            if (ownplay && target.Angr>0)
            {
                int dmg = target.Angr;
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos + 1 == target.zonepos || m.zonepos-1 == target.zonepos)
                    {
                        p.minionGetDamageOrHeal(m, dmg);
                        if (!target.silenced && target.handcard.card.name == CardDB.cardName.waterelemental) m.frozen=true;
                        if (!target.silenced && !m.immune && !m.divineshild && target.poisonous) p.minionGetDestroyed(m);
                    }
                }

            }
		}

	}
}