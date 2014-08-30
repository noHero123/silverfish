using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_408 : SimTemplate //mortalstrike
	{

//    verursacht $4 schaden. verursacht stattdessen $6 schaden, wenn euer held max. 12 leben hat.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = 0;

            if (ownplay)
            {
                dmg = (p.ownHero.Hp <= 12) ? p.getSpellDamageDamage(6) : p.getSpellDamageDamage(4);
            }
            else
            {
                dmg = (p.enemyHero.Hp <= 12) ? p.getEnemySpellDamageDamage(6) : p.getEnemySpellDamageDamage(4);
            }
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}