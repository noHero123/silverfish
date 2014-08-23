using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_093 : SimTemplate //defenderofargus
	{

//    kampfschrei:/ verleiht benachbarten dienern +1/+1 und spott/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos)//position and position -1 because its not placed jet
                {
                    m.taunt = true;
                    p.minionGetBuffed(m, 1, 1);
                }
            }
		}


	}
}