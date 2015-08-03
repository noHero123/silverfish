using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_259 : SimTemplate//Lightning Storm
    {

        //Deal $2-$3 damage to all enemy minions. Overload: (2)
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.isServer)
            {
                List<Minion> temp = (!ownplay) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    int random = p.getRandomNumber_SERVER(2, 3);
                    int dmgs = (ownplay) ? p.getSpellDamageDamage(random) : p.getEnemySpellDamageDamage(random);
                    p.minionGetDamageOrHeal(m, dmgs, true);
                }
                if (ownplay) { p.owedRecall += 2; } else { p.enemyRecall += 2; };
                return;
            }
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            if (ownplay) { p.owedRecall += 2; } else { p.enemyRecall += 2; };
        }

    }
}
