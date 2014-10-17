using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_537 : SimTemplate //explosiveshot
	{

//    fügt einem diener $5 schaden und benachbarten dienern $2 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg1 = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            int dmg2 = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmg1);
            foreach (Minion m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos) p.minionGetDamageOrHeal(m, dmg2);
            }
		}

	}
}