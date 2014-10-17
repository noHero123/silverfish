using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_251 : SimTemplate //forkedlightning
	{

//    fügt zwei zufälligen feindlichen dienern $2 schaden zu. überladung:/ (2)
        //todo list
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            List<Minion> temp2 = new List<Minion>(p.enemyMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
            int i = 0;
            foreach (Minion enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2) break;
            }
            if (ownplay) p.ueberladung += 2;
		}

	}
}