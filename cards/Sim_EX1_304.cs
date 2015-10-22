using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_304 : SimTemplate //voidterror
	{

//    kampfschrei:/ vernichtet die benachbarten diener und verleiht ihm deren angriff und leben.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            int angr = 0;
            int hp = 0;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos || m.zonepos == own.zonepos - 1)
                {
                    angr += m.Angr;
                    hp += m.Hp;
                    if (m.Ready) p.evaluatePenality += m.Angr;//DIRTY Penalty-fix (cause i dont pass the place to penmanager->getplaycardpen())
                    if (m.destroyOnOwnTurnEnd && !m.Ready) p.evaluatePenality -= 50;//same as penaltymanager->getAttackWithMininonPenality(...)
                    //otherwise it would be a little bit more stuff to calculate
                    p.minionGetDestroyed(m);
                }
            }
            p.minionGetBuffed(own, angr, hp);
		}


	}
}