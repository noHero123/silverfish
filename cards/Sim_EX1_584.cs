using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_584 : SimTemplate //ancientmage
	{
//    kampfschrei:/ verleiht benachbarten dienern zauberschaden +1/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos || m.zonepos + 1 == own.zonepos)
                {
                    m.spellpower++;
                    if (own.own)
                    {
                        p.spellpower++;
                    }
                    else
                    {
                        p.enemyspellpower++;
                    }
                }
            }
		}


	}
}