using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DS1_183 : SimTemplate //multishot
	{

//    fügt zwei zufälligen feindlichen dienern $3 schaden zu.
        //todo new list
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.isServer)
            {
                int damageS = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                List<Minion> temp22 = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
                if (temp22.Count < 2) return;
                int random1 = p.getRandomNumber_SERVER(0, temp22.Count-1);
                int random2 = p.getRandomNumber_SERVER(0, temp22.Count-2);
                if (random2 >= random1) random2++;

                p.minionGetDamageOrHeal(temp22[random1], damageS);
                p.minionGetDamageOrHeal(temp22[random2], damageS);
                
                return;
            }

            int damage = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            List<Minion> temp2 = (ownplay) ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions) ;
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
            int i = 0;
            foreach (Minion enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2) break;
            }
		}

	}
}