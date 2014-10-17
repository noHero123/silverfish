using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_007 : SimTemplate //starfall
	{

//    wählt aus:/ fügt einem diener $5 schaden zu; oder fügt allen feindlichen dienern $2 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                p.minionGetDamageOrHeal(target, dmg);
            }
            if (choice == 2)
            {
                int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                p.allMinionOfASideGetDamage(!ownplay, damage);
            }

		}

	}
}