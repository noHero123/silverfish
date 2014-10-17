using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_275 : SimTemplate //coneofcold
	{

//    friert/ einen diener sowie seine benachbarten diener ein und fügt ihnen $1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            target.frozen = true;
            List<Minion> temp = (target.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (target.zonepos == m.zonepos + 1 || target.zonepos + 1 == m.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                    m.frozen = true;
                }

            }
		}


	}
}