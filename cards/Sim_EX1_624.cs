using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_624 : SimTemplate //holyfire
	{

//    verursacht $5 schaden. stellt bei eurem helden #5 leben wieder her.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            int heal = (ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);
            if (ownplay) p.minionGetDamageOrHeal(p.ownHero, -heal);
            else p.minionGetDamageOrHeal(p.enemyHero, -heal);
		}

	}
}