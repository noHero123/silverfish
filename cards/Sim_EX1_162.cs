using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_162 : SimTemplate //direwolfalpha
	{

//    benachbarte diener haben +1 angriff.
        // note buff and debuff is handled by playfield (faster)
        /*
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.zonepos-1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, 1, 0);
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos-1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, 1, 0);
                    }
                }
            }

		}


        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, -1, 0);
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.zonepos - 1 == own.zonepos || m.zonepos + 1 == own.zonepos)
                    {
                        p.minionGetAdjacentBuff(m, -1, 0);
                    }
                }
            }
        }*/

	}
}